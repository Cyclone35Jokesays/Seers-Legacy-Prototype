using UnityEngine;
using System;

public class IncreaseHealth : MonoBehaviour, ICollectible
{
    // public Animator anim;

    private Vector2 loc;
    public event Action<GameObject> OnCollected;

    private void Start()
    {
      //  anim.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            //anim.Play("Secret Message");
            collision.GetComponent<Health>().health += 1;
            collision.GetComponent<Health>().numOfHearts += 1;
            OnCollected.Invoke(this.gameObject);
            Destroy(gameObject);
        }

    }
}
