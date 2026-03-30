using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
<<<<<<< Updated upstream
=======
    public Transform focalPoint;
    public GameObject powerIndicatorPrefab;
    public float powerUpStrength = 15f;
>>>>>>> Stashed changes

    private Rigidbody rb;
    private InputAction moveAction;
    private InputAction breakAction;
    private bool hasPowerUp = false;

<<<<<<< Updated upstream
=======
    private GameObject currentPowerIndicator;
>>>>>>> Stashed changes

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        breakAction = InputSystem.actions.FindAction("Break");
    }

    // Update is called once per frame
    void Update()
    {

<<<<<<< Updated upstream
    }
}
=======
        if (breakAction != null && breakAction.IsPressed())
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (currentPowerIndicator != null)
        {
            currentPowerIndicator.transform.position = transform.position + new Vector3(0f, -0.3f, 0f);
            currentPowerIndicator.transform.rotation = Quaternion.Euler(0f, currentPowerIndicator.transform.rotation.eulerAngles.y, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;

            if (currentPowerIndicator == null && powerIndicatorPrefab != null)
            {
                currentPowerIndicator = Instantiate(
                    powerIndicatorPrefab,
                    transform.position + new Vector3(0f, -0.3f, 0f),
                    Quaternion.identity
                );
            }

            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(10f);

        hasPowerUp = false;

        if (currentPowerIndicator != null)
        {
            Destroy(currentPowerIndicator);
            currentPowerIndicator = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            if (enemyRb != null)
            {
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                enemyRb.AddForce(awayFromPlayer.normalized * powerUpStrength, ForceMode.Impulse);
            }
        }
    }
}
>>>>>>> Stashed changes
