using UnityEngine;
using System;

public class IncreaseHealth : MonoBehaviour //ICollectible
{
    // public Animator anim;

    // private Vector2 loc;
    // public event Action<GameObject> OnCollected;
    private Health player;

    private void Start()
    {
        //  anim.GetComponent<Animator>();
        player = GameManager.Instance.player.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.tag == "Player")
        {
            //anim.Play("Secret Message");
           collision.gameObject.GetComponent<Health>().health += 1;
           collision.gameObject.GetComponent<Health>().numOfHearts += 1;
            // OnCollected.Invoke(this.gameObject);
           gameObject.SetActive(false);
        }
    }
}
