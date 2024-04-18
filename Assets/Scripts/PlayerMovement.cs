using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private PlayerInput playerInput;
    private InputActions inputActions;
    isGrounded isGrounded;

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 3f;
    private float horizontal = Input.GetAxis("Horizontal");

    private bool isMoving;
    private bool facingRight;

    private void Awake()
    {
        isGrounded = GetComponent<isGrounded>();
        playerInput = GetComponent<PlayerInput>();

        inputActions = new InputActions();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y); //using velocity for movement

        if (facingRight && horizontal > 0f)
        {
            Flip();
        }
        if (!facingRight && horizontal < 0f) 
        {
            Flip();
        }
    }

    public void Moving(InputAction.CallbackContext value)
    {
        horizontal = value.ReadValue<Vector2>().x; //doesn't need to be checked if performed
    }

    public void Jump(InputAction.CallbackContext button)
    {
        if (button.performed && isGrounded.playerGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}