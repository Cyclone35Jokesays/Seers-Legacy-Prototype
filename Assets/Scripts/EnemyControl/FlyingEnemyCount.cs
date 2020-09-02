using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyCount : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    public GameObject Health;
    public GameObject block;

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(Health, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(block);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
