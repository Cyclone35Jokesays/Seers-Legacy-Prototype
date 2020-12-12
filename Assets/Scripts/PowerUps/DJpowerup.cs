using System;
using UnityEngine;
using System.Collections;

public class DJpowerup : MonoBehaviour
{
   // public Animator anim;

    private void Start()
    {
        //anim.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("Spawn");
            //anim.Play("Secret Message");
            collision.gameObject.GetComponent<PlayerController>().extraJumpValue += 1;
            // OnCollected.Invoke(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}
