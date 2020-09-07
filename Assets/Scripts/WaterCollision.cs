using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterCollision : MonoBehaviour
{
    private Health damage;
    private PlayerController play;
    

    private void Awake()
    {
        play = GameManager.Instance.player.GetComponent<PlayerController>();
        damage = GameManager.Instance.player.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            damage.takeDamage();
            StartCoroutine(play.Knockback(0.01f, 400, play.transform.position));
        }


    }
}
