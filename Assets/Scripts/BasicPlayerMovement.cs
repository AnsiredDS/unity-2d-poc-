using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    float movement;
    [SerializeField] float speed;

    bool isGrounded;
    [SerializeField] float jumpForce, checkRadius;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask isGround;


    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y); 

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
