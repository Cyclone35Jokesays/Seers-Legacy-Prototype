using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Blaster blaster;

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

    private GameMaster gm; 

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
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
         if (Input.GetKeyDown(KeyCode.R))
         {
             Debug.Log("I am teleporting");
             transform.position = gm.lastCheckPointPos;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         } 

        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
            anim.SetBool("IsJumping", false);
        }
        if (isGrounded == false)
        {
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            SoundManager.PlaySound("Jump");
        }

        else if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
            extraJumps--;           
        }

        if (Input.GetKey(KeyCode.W) && isJumping)
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

    public IEnumerator Knockback(float knockDuration, float knockPower, Vector2 knockbackDirection)
    {
        float timer = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        while( knockDuration > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector2(knockbackDirection.x * -100, knockbackDirection.y + knockPower));
        }
        yield return 0;
    }
}
