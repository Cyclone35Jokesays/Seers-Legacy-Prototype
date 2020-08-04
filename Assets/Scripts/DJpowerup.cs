using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJpowerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().extraJumpValue += 1;
            Destroy(gameObject);
        }
    }
}
