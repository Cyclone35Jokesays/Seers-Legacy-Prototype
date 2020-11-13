using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int health;
    [SerializeField]
    public GameObject deathEffect;
    public GameObject Health;
    private PlayerController pc;

    private void Start()
    {
        pc = GameManager.Instance.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            SoundManager.PlaySound("EnemyDeath");
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
