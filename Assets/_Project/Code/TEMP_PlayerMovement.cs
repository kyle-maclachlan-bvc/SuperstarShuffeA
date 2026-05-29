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
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float mouseSensitivity = 100f;
    
    private Vector2 moveInput;
    private Vector2 lookInput;
    private CharacterController controller;
    private float verticalVelocity;
    private float pitch;

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

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    private void Update()
    {
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

    private void LateUpdate()
    {
        // Horizontal mouse movement
        transform.Rotate(
            Vector3.up,
            lookInput.x * mouseSensitivity * Time.deltaTime
        );

        // Vertical mouse movement
        pitch -= lookInput.y * mouseSensitivity * Time.deltaTime;

        pitch = Mathf.Clamp(
            pitch,
            -45f,
            70f
        );
        
        cameraPivot.localRotation =
            Quaternion.Euler(
                pitch,
                0f,
                0f
            );
    }
}
