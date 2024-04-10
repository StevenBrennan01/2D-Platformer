using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    [SerializeField] private float jumpForce = 10f;

    isGrounded isGrounded;

    private void Update()
    {
        Moving();
        Jumping();
    }

    private void Moving()
    {
        float dirX = Input.GetAxis/*raw*/("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
    }

    private void Jumping()
    {
        //if (isGrounded.playerGrounded)
        //{
        //    if (Input.GetButtonDown("Jump"))
        //    {
        //        rb.velocity = new Vector2(0, jumpForce);
        //    }
        //}

        if (Input.GetButtonDown("Jump"))
        {
           if (isGrounded.playerGrounded)
            {
                rb.velocity = new Vector2(0, jumpForce);
            }
        }
    }
}