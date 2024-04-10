using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float inputValue = 5f;

    isGrounded isGrounded;
    InputActions inputActions;

    private bool isMoving;

    private void Awake()
    {
        isGrounded = GetComponent<isGrounded>(); //POPULATE SCRIPTS HERE
        
        inputActions = new InputActions();
        inputActions.Player.Enable();

        inputActions.Player.Moving.performed += Moving;
    }

    private void Update()
    {
        //Moving(); //working on refactoring to new input system
        Jumping();
    }

    private void Moving(InputAction.CallbackContext value)
    {
        isMoving = true;

    }

    #region OldInputMoving
    //private void Moving()
    //{
    //    float dirX = Input.GetAxis/*raw*/("Horizontal");
    //    rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
    //}
    #endregion

    #region OldInputJumping
    private void Jumping()
    {
        if (isGrounded.playerGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
            }   
        }
    }
    #endregion
}