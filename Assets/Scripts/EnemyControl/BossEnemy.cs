using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    public Slider HealthBar;

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SceneManager.LoadScene(12);
        }
        HealthBar.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
