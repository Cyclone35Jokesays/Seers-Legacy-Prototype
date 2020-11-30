using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriplePowerup : MonoBehaviour
{
    Blaster blast;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<PlayerController>();
            player.blaster.trip = true;
            Destroy(gameObject);
        }       
    }
}