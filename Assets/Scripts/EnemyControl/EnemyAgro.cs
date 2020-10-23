using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    public float agroRange;
    [SerializeField]
    float moveSpeed;

    private Animator anim;

    Rigidbody2D rb2d;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroRange)
        {
            anim.SetBool("Aware", true);
            ChasePlayer();
        }

        else
        {
            anim.SetBool("Aware", false);
            StopChasingPlayer();
        }
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }

        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;

    }
}
