using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    private float jumpTimeCounter;
    public float jumpTime;
    bool isJumping;
    
    public Animator anim;
    private int input;

    private void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
        {
            SoundManager.PlaySound("Running");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SoundManager.PlaySound("Running");
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
            anim.SetBool("IsJumping", false);
        }
        if (isGrounded == false)
        {
            anim.SetBool("IsJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            SoundManager.PlaySound("Jump");
        }

        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
        
    }
}
