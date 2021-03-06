﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JumpEnemyAttacker : MonoBehaviour
{
    [Header("For Petrolling")]
    [SerializeField]
    public float moveSpeed;
    private float moveDirection = 1;
    private bool facingRight = true;
    [SerializeField]
    public Transform groundCheckPoint;
    [SerializeField]
    public Transform wallCheckPoint;
    [SerializeField]
    public float circleRadius;
    [SerializeField]
    public LayerMask groundLayer;
    private bool checkingGround;
    private bool checkingWall;

    [Header("For JumpAttacking")]
    [SerializeField]
    public float jumpHeight;

    [SerializeField]
    public Transform player;
    [SerializeField]
    public Transform groundCheck;
    [SerializeField]
    public Vector2 boxSize;
    private bool isGrounded;

    [Header("For SeeingPlayer")]
    [SerializeField]
    public Vector2 lineOfSite;
    [SerializeField]
    public LayerMask playerLayer;
    [SerializeField]
    public float aggroDistance = 9.0f;
    private bool canSeePlayer;

    public BossEnemy HP;

    [Header("Other")]
    private Animator enemyAnim;
    private Rigidbody2D enemyRB;

    [Header("Shooting")]
   // private float timeBtwShots;
   // [SerializeField]
    //public float startTimeBtwShots;
    public GameObject projectile;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
       // timeBtwShots = startTimeBtwShots;
        player = GameManager.Instance.player.transform;
        HP = GetComponent<BossEnemy>();
    }

    private void Update()
    {
       /* if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (HP.health == 10)
        {
            moveSpeed = 4.2f;
            jumpHeight = 12;
            aggroDistance = 10.5f;
            startTimeBtwShots = 1.5f;
        } */
    }

    private void FixedUpdate()
    {
        checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);

        float distToPlayer = Vector2.Distance(transform.position, player.position);
        canSeePlayer = (distToPlayer <= aggroDistance);

        AnimationController();

        if (!canSeePlayer && isGrounded)
        {
            Petrolling();
        }

        FlipTowardsPlayer();
    }

    public void Petrolling()
    {
        if (!checkingGround || checkingWall)
        {
            if (facingRight)
            {
                Flip();
            }
            else if (!facingRight)
            {
                Flip();
            }
        }
        enemyRB.velocity = new Vector2(moveSpeed * moveDirection, enemyRB.velocity.y);
    }

    public void JumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if (isGrounded)
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }

    public void FlipTowardsPlayer()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        if (distanceFromPlayer < 0 && facingRight)
        {
            Flip();
        }
        else if (distanceFromPlayer > 0 && !facingRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void AnimationController()
    {
        enemyAnim.SetBool("CanSeePlayer", canSeePlayer);
        enemyAnim.SetBool("IsGrounded", isGrounded);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckPoint.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckPoint.position, circleRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroDistance);

    }
}
