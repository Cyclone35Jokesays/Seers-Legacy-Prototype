using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    private GameMaster gm;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;
    private PlayerController player;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameManager.Instance.player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void takeDamage()
    {
        health -= 1;
    }

    public void restoreHealth()
    {
        health += 1;
    }

    public void restartHP()
    {
        health += 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            StartCoroutine(player.Knockback(0.01f, 400, player.transform.position));

            if (health <= 0)
            {
                restartHP();
                transform.position = gm.lastCheckPointPos;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);           
            }
        }

        if (collision.gameObject.tag == "Boss")
        {
            health -= 1;
            StartCoroutine(player.Knockback(0.01f, 400, player.transform.position));

            if (health <= 0)
            {
                restartHP();
                transform.position = gm.lastCheckPointPos;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (health <= 0)
            {
                restartHP();
                transform.position = gm.lastCheckPointPos;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
