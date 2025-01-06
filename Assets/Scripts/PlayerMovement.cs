using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 Movement;
    Rigidbody rigidBody;
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float xClamp = 3f;
    [SerializeField] float zClamp = 2f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandelMovement();
    }

    public void Move(InputAction.CallbackContext callback)
    {
        Movement = callback.ReadValue<Vector2>();
    }

    private void HandelMovement()
    {
        Vector3 CurrentPosition = rigidBody.position;
        Vector3 moveDirection = new Vector3(Movement.x, 0, Movement.y);
        Vector3 newPosition = CurrentPosition + moveDirection * MoveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);

        rigidBody.MovePosition(newPosition);
    }
}
