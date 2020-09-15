using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriplePowerup : MonoBehaviour
{
    Blaster blast;
    public Animator anim;

    private void Start()
    {
        anim.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("Secret Message");
            var player = collision.GetComponent<PlayerController>();
            player.blaster.trip = true;
            Destroy(gameObject);
        }       
    }
}