using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public  Rigidbody2D  playerRb;
    public  float    speed;
    public  float    input;
    public  SpriteRenderer    spriteRenderer;
    public  int  jumpForce;
    public  LayerMask    groundLayer;
    public  LayerMask    platformLayer;
    public  LayerMask    darkLayer;
    public  LayerMask    playerLayer;
    private bool    isGrounded;
    private bool    isPlatform;
    public  Transform   feetPosition;
    public  float   groundCheckCircle;
    public  float   jumpTime;
    private float   jumpTimeCounter;
    private bool    isJumping;
    private int jumpNumber;
    public  Inventory   inventory;
    private int playerLayerID;
    private int platformLayerLayerID;

    // Start is called before the first frame update
    void Start()
    {
        playerLayerID = LayerMask.NameToLayer("Player");
        platformLayerLayerID = LayerMask.NameToLayer("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        if (input < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (input > 0)
        {
            spriteRenderer.flipX = false;
        }
       
        if (isGrounded == true || isPlatform == true)
        {
            jumpNumber = 0;
        }

        if (((isGrounded == true || isPlatform == true) || (jumpNumber < 2 && inventory.doubleJump == true)) && Input.GetButtonDown("Jump"))
        {
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpNumber++;
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }


        if (Input.GetKeyDown(KeyCode.S) && isPlatform == true)
        {
            StartCoroutine(FallTimer());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = true;
        else if (other.gameObject.CompareTag("Platform"))
            isPlatform = true;
        /*else if (!isGrounded && !isPlatform)
            speed = 0;*/
    }
    
    /*private void OnCollisionStay2D(Collision2D other)
    {
        if (isGrounded || isPlatform)
           speed = 10;
    }*/

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = false;
        if (other.gameObject.CompareTag("Platform"))
            isPlatform = false;
        /*speed = 10;*/
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
    }

    IEnumerator FallTimer()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.20f);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
