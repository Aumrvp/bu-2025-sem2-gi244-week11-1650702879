using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int totalSpawnEnemies;
        public int numberOfRandomSpawnPoint;
        public float delayStart;
        public float spawnInterval;
        public int numberOfPowerUp;
    }

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public Wave[] waves;

    private int currentWaveIndex = 0;

    void Start()
    {
        StartCoroutine(WaveRoutine());
    }

    IEnumerator WaveRoutine()
    {
        while (currentWaveIndex < waves.Length)
        {
            Wave currentWave = waves[currentWaveIndex];

            List<Transform> selectedSpawnPoints = GetRandomSpawnPoints(currentWave.numberOfRandomSpawnPoint);

            for (int i = 0; i < currentWave.numberOfPowerUp; i++)
            {
                Transform powerUpSpawnPoint = selectedSpawnPoints[Random.Range(0, selectedSpawnPoints.Count)];
                Instantiate(powerUpPrefab, powerUpSpawnPoint.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(currentWave.delayStart);

            for (int i = 0; i < currentWave.totalSpawnEnemies; i++)
            {
                Transform enemySpawnPoint = selectedSpawnPoints[Random.Range(0, selectedSpawnPoints.Count)];
                Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);

                yield return new WaitForSeconds(currentWave.spawnInterval);
            }

            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length == 0);

            currentWaveIndex++;
        }

        Debug.Log("All waves completed");
    }

    List<Transform> GetRandomSpawnPoints(int count)
    {
        List<Transform> availablePoints = new List<Transform>(spawnPoints);
        List<Transform> selectedPoints = new List<Transform>();

        count = Mathf.Min(count, availablePoints.Count);

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);
            selectedPoints.Add(availablePoints[randomIndex]);
            availablePoints.RemoveAt(randomIndex);
        }

        return selectedPoints;
    }
}