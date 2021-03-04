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
    public static bool canShoot = true;

    public float jumpForce;
    public Transform feet;
    public LayerMask groundLayers;

    private float moveX;
    private int head = 1;

    [HideInInspector] public bool isFacingRight = true;

    private void Update()
    {
        Debug.Log(canShoot);
        if (Input.GetKeyDown("1"))
        {
            head = 1;
        }
        else if (Input.GetKeyDown("2"))
        {
            head = 2;
        }
        else if (Input.GetKeyDown("3"))
        {
            head = 3;
        }
       
        headChosen(head);

        moveX = Input.GetAxisRaw("Horizontal"); //GetAxisRaw - input will always be -1, 0, 1; Horizontal = A / D, aL / aR

        if (Input.GetButtonDown("Jump") && isGrounded()) //If needed to hold the button = GetButton; reads only the first click 
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
            transform.localScale = new Vector3(2f, 2f, 1f); //Setting sprites with right scale
            isFacingRight = true;
        } else if (moveX < 0f)
        {
            transform.localScale = new Vector3(-2f, 2f, 1f);
            isFacingRight = false;
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

    private void headChosen(int head)
    {
        switch (head)
        {
            case 1:
                jumpForce = 24f;
                movementSpeed = 10f;
                canShoot = true;
                Debug.Log("Chosen head 1: normal jump, normal speed, can shoot");
                break;
            case 2:
                jumpForce = 28f;
                movementSpeed = 10f;
                canShoot = false;
                Debug.Log("Chosen head 2: higher jump, normal speed, cannot shoot");
                break;
            case 3:
                jumpForce = 24f;
                movementSpeed = 16f;
                canShoot = false;
                Debug.Log("Chosen head 3: normal jump, super speed, cannot shoot");
                break;
            default:
                break;
        }
    }
}
