using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private InputAction moveAction;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        transform.Rotate(Vector3.up, move.x * rotationSpeed * Time.deltaTime);
    }
}