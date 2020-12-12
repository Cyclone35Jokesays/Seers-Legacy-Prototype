using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimBoss : MonoBehaviour
{
    public Animator miniBoss;

    private void Start()
    {
        miniBoss.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            miniBoss.SetBool("playing", true);
            Destroy(gameObject);
        }
    }
}
