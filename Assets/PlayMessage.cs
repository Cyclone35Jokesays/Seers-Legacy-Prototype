using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMessage : MonoBehaviour
{
    public Animator message;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            message.SetBool("Active", true);
            SoundManager.PlaySound("Gust");
            gameObject.SetActive(false);
        }

        
    }
}
