﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //anim.Play("Secret Message");
            collision.gameObject.GetComponent<PlayerController>().extraJumpValue += 1;
            // OnCollected.Invoke(this.gameObject);
            Destroy(gameObject);
        }
    }
}
