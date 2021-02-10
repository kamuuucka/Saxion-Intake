using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator anim;

    public float jumpForce = 30f;
    public Transform feet;
    public LayerMask groundLayers;

    private float moveX;

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal"); //GetAxisRaw - input will always be -1, 0, 1; Horizontal = A / D, aL / aR

        if (Input.GetButtonDown("Jump") && isGrounded())        //If needed to hold the button = GetButton; reads only the first click 
        {
            Jump();
        }

        if (Mathf.Abs(moveX) > 0.05)            //Returns absolute value (wart. bez.) so you can run in every direction
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (moveX > 0f)
        {
            transform.localScale = new Vector3(2f, 2f, 1f);
        } else if (moveX < 0f)
        {
            transform.localScale = new Vector3(-2f, 2f, 1f);
        }
        
        anim.SetBool("isGrounded", isGrounded());
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveX * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    private void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    private bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }
}
