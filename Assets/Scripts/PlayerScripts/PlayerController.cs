﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Blaster blaster;
    [Header("Movement")]
    [SerializeField]
    public float speed;
    [SerializeField]
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;

    public enum PlayerState
    {
        idleState,
        runState,
        JumpState,
        WallGrabState
    }

    public PlayerState playerState;
    
    [Header("Ground Touching")]
    private bool isGrounded;
    public Transform groundCheck;
    [SerializeField]
    public float checkRadius;
    [SerializeField]
    public LayerMask whatIsGround;

    [Header("WallJumping")]
    public Transform wallGrabPoint;
    private bool canGrab, isGrabbing;
    private float gravityStore;
    [SerializeField] float wallJumpTime = .2f;
    private float wallJumpCounter;

    [Header("DoubleJump")]
    private int extraJumps;
    public int extraJumpValue;
    private float jumpTimeCounter;
    [SerializeField]
    public float jumpTime;
    bool isJumping;

    [Header("Misc")]
    [SerializeField]
    public ParticleSystem dust;   
    [SerializeField]
    private Animator anim;
    // private GameMaster gm;
    public GameObject DJEffect;
    public GameObject LightObject;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GameManager.Instance.player = gameObject;
    }

    private void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        gravityStore = rb.gravityScale;
       // gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
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
        switch (playerState)
        {
            case PlayerState.idleState:
                break;
            case PlayerState.runState:

                void CreateDust()
                {
                    dust.Play();
                }

                if (Input.GetKey(KeyCode.A))
                {
                    CreateDust();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    CreateDust();
                }
                break;
            case PlayerState.JumpState:
                break;
            case PlayerState.WallGrabState:
                break;               
        }

        if (wallJumpCounter <= 0)
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

            if (Input.GetKeyDown(KeyCode.W) && isGrounded || Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
                SoundManager.PlaySound("Jump");
            }

            else if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0 || Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter = jumpTime;
                Instantiate(DJEffect, transform.position, transform.rotation);
                extraJumps--;
            }

            if (Input.GetKey(KeyCode.W) && isJumping || Input.GetKey(KeyCode.Space) && isJumping)
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

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }

            canGrab = Physics2D.OverlapCircle(wallGrabPoint.position, .2f, whatIsGround);

            isGrabbing = false;
            if (canGrab && !isGrounded)
            {
                float localYRot = transform.localRotation.eulerAngles.y;
                float horizontalInputDir = Input.GetAxisRaw("Horizontal");
                if ((localYRot == 0 && horizontalInputDir > 0) || (localYRot == 180 && horizontalInputDir < 0))
                {
                    isGrabbing = true;
                }
            }

            if (isGrabbing)
            {
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
                {
                    wallJumpCounter = wallJumpTime;

                    rb.velocity = new Vector2(-Input.GetAxisRaw("Horizontal") * speed, jumpForce);
                    rb.gravityScale = gravityStore;
                    isGrabbing = false;
                }
            }

            else
            {
                rb.gravityScale = gravityStore;
            }
        }

        else
        {
            wallJumpCounter -= Time.deltaTime;
        }

        anim.SetBool("IsGrabbing", isGrabbing);
    }   
}
/*public IEnumerator Knockback(float knockDuration, float knockPower, Vector2 knockbackDirection)
    {
        float timer = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        while( knockDuration > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector2(knockbackDirection.x * -100, knockbackDirection.y + knockPower));
        }
        yield return 0;
    }   */
