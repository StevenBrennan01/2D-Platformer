using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public bool playerGrounded;

    [SerializeField] LayerMask groundMask;
    void Update()
    {
        float playerDistance = transform.localScale.y / 0.85f; 
        RaycastHit2D floorHit = Physics2D.Raycast(transform.position, -Vector2.up, playerDistance, groundMask); 

        if (floorHit.collider != null)
        {
            Debug.Log("grounded");
            playerGrounded = true;
        }

        else playerGrounded = false;

        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - playerDistance, 0), Color.red, 2f);
    }
}