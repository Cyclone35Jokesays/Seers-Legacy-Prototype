using UnityEngine;
using System;

public class IncreaseHealth : MonoBehaviour //ICollectible
{
    private Health player;

    private void Start()
    {
        player = GameManager.Instance.player.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("Spawn");
            collision.gameObject.GetComponent<Health>().health += 1;
            collision.gameObject.GetComponent<Health>().numOfHearts += 1;
            gameObject.SetActive(false);
        }
    }
}
