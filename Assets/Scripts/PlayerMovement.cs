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
    private bool    isGrounded;
    public  Transform   feetPosition;
    public  float   groundCheckCircle;
    public  float   jumpTime;
    private float   jumpTimeCounter;
    private bool    isJumping;
    private int jumpNumber;
    public  Inventory   inventory;

    // Start is called before the first frame update
    void Start()
    {}

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

        if (Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer) || Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, platformLayer))
            isGrounded = true;
        else
            isGrounded = false;
        
        if (isGrounded == true)
        {
            jumpNumber = 0;
        }

        if ((isGrounded == true || (jumpNumber < 2 && inventory.doubleJump == true)) && Input.GetButtonDown("Jump"))
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


        if (Input.GetKeyDown(KeyCode.S) && Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, platformLayer))
        {
            StartCoroutine(FallTimer());
        }
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
    }

    IEnumerator FallTimer()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
