using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TEMP_PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 180f;
    [SerializeField] private Transform eyes;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float gravity = -20f;
    
    private Vector2 moveInput;
    private CharacterController controller;
    private float verticalVelocity;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }

    public void OnJump(InputValue value)
    {
        if (controller.isGrounded)
            verticalVelocity = jumpForce;
    }

    private void Update()
    {
        // Rotation
        transform.Rotate(
            Vector3.up,
            moveInput.x * turnSpeed * Time.deltaTime
        );

        // Forward / Backward movement
        Vector3 movement = transform.forward * moveInput.y * moveSpeed;

        // Gravity
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        movement.y = verticalVelocity;

        controller.Move(movement * Time.deltaTime);
    }
}
