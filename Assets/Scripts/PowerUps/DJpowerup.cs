using System;
using UnityEngine;

public class DJpowerup : MonoBehaviour, ICollectible
{
    public Animator anim;
    private Vector2 loc;

    public event Action<GameObject> OnCollected;

    private void Awake()
    {
        
    }

    private void Start()
    {
        //anim.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //anim.Play("Secret Message");
            collision.gameObject.GetComponent<PlayerController>().extraJumpValue += 1;
            OnCollected.Invoke(this.gameObject);
            Destroy(gameObject);
        }
    }
}
