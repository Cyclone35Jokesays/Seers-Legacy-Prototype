using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    public GameObject deathEffect;
    public GameObject Health;
    
    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(Health, transform.position, Quaternion.identity);
            Destroy(gameObject);           
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
