using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChest : MonoBehaviour
{
    float movement;
    [SerializeField] float speed;
    Rigidbody2D rb;

    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpForce, checkRadius;
    [SerializeField] LayerMask isGround;
    bool isGrouded, facingRight = true;
    public int coinAmount, keyAmount;

    Transform leftBound, rightBound;
    GameObject chest;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftBound = GameObject.Find("Left Bound").GetComponent<Transform>();
        rightBound = GameObject.Find("Right Bound").GetComponent<Transform>();
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        isGrouded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGrouded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }
        
        ////Flip
        if(facingRight == false && movement > 0) {
            Flip();
        }
        else if (facingRight == true && movement < 0) {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Border") {
            if(other.gameObject.name == "Left Bound") {
                rb.position = new Vector3 (rightBound.position.x - 1, rb.position.y);
                Debug.Log("Entered on the Left Bound");
            }

            if(other.gameObject.name == "Right Bound") {
                rb.position = new Vector3 (leftBound.position.x + 1, rb.position.y);
                Debug.Log("Entered on the Right Bound");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag  == "Chest") {
            chest = other.gameObject;
            if(Input.GetKeyDown(KeyCode.E) && chest.GetComponent<ChestScript>().opened == false) {
                chest.GetComponent<ChestScript>().opened = true;
                Debug.Log("The chest was opened!");
            }
            
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
