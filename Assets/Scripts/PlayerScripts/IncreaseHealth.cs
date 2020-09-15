using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseHealth : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            anim.Play("Secret Message");
            collision.GetComponent<Health>().health += 1;
            collision.GetComponent<Health>().numOfHearts += 1;
            Destroy(gameObject);
        }

    }
}
