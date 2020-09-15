using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJpowerup : MonoBehaviour
{
    public Animator anim;
    private Vector2 loc;

    private void Awake()
    {
        
    }

    private void Start()
    {
        anim.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.Play("Secret Message");
            collision.gameObject.GetComponent<PlayerController>().extraJumpValue += 1;
            Destroy(gameObject);
        }
    }
}
