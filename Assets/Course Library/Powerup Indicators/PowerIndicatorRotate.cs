using UnityEngine;

public class PowerIndicatorRotate : MonoBehaviour
{
    public float rotateSpeed = 180f;

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }
}