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


    private void Start()
    {
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
            player.MethodThatTriggersInvulnerability();

            if (health <= 0)
            {
                restartHP();
                transform.position = GameManager.Instance.lastCheckPointPos;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);           
            }
        }

        if (collision.gameObject.tag == "Boss")
        {
            health -= 1;
            player.MethodThatTriggersInvulnerability();

            if (health <= 0)
            {
                restartHP();
                transform.position = GameManager.Instance.lastCheckPointPos;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            player.MethodThatTriggersInvulnerability();

            if (health <= 0)
            {
                restartHP();
                transform.position = GameManager.Instance.lastCheckPointPos;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
