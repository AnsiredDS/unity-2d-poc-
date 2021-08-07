using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed, jumpForce, checkRadius, zipVelocity;
    float movement, zipMovement;
    bool canMove, isGrounded; 
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask isGround;
    
    //ZIPLINE 
    [SerializeField] bool isZipped;
    [SerializeField] Transform pointA, pointB;

    //CHEST
    GameObject chest;

    void Start()
    {
        isZipped = false;
        canMove = true;
        
    }

    void Update()
    {
    

    if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true) {
        rb.velocity = Vector2.up * jumpForce;
        }    

    if(isZipped == true) {
        canMove = false;
        
    }

    else {
        canMove = true;
    }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround);

        if (canMove == true) {
            movement = Input.GetAxisRaw("Horizontal");
        }

        else {
            movement = 0;
        }
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        ///////////////////// Zip Section
        if (isZipped == true) {
            GetComponent<Rigidbody2D>().gravityScale = 0;

            if (zipMovement >= 0 && zipMovement <= 1) {
                zipMovement += Input.GetAxisRaw("Horizontal") * zipVelocity * Time.fixedDeltaTime;
                transform.position = Vector2.Lerp(pointA.position, pointB.position, zipMovement);
            }

            if (zipMovement > 1) {
                zipMovement = 1;
            }
            
            if (zipMovement < 0) {
                zipMovement = 0;
            }
            
        }

        else {
            GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        }

        Debug.Log(isZipped);

        if(Input.GetKeyDown(KeyCode.Space) && isZipped == true) {
                Debug.Log("Exit the Zipline!");
                isZipped = false;
                pointA = null;
                pointB = null;

                zipMovement = 0;
        } 
    }

    void GrappleLerp() {

    }

    private void OnTriggerStay2D(Collider2D other) {
        //Debug.Log(other);
        if (other.gameObject.tag == "Grapple") {
            if(Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("Enter the Zipline!");
                isZipped = true; 
               // GetComponent<PlayerLerp>().enabled = true;
                rb.position = other.GetComponent<Transform>().position;

                pointA = other.GetComponent<Grapple>().grappleA;
                pointB = other.GetComponent<Grapple>().grappleB;

            if(other.gameObject.name == "Grapple B" && Input.GetKeyDown(KeyCode.E)) {
                    zipMovement = 1;    
                }
            }
        }


        

         
    /*
       if (other.gameObject.tag == "Grapple" && isZipped == true) {
           
       } */ 
    }
}
