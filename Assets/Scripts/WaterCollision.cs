using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterCollision : MonoBehaviour
{
    private Health damage;
    private PlayerController player;

    private void Awake()
    {
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            damage.takeDamage();
            StartCoroutine(player.Knockback(0.01f, 400, player.transform.position));
        }


    }
}
