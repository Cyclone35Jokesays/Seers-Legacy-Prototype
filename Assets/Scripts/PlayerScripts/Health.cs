using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Values")]
    public int health;
    public int numOfHearts;

    [Header("General")]
    private GameMaster gm;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;
    private PlayerController player;
    private Knockback KB;
    private Invincible IN;
    [SerializeField]
    public SpriteRenderer spriteDmg;

    [Header("Colors")]
    private Color normal = new Color(255, 255, 255);
    private Color RedHurt = new Color(255, 145, 145);
    private Color GreenHeal = new Color(129, 255, 114);


    private void Start()
    {
        player = GameManager.Instance.player.GetComponent<PlayerController>();
        KB = GetComponent<Knockback>();
        IN = GetComponent<Invincible>();
        spriteDmg.GetComponent<SpriteRenderer>();
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
        spriteDmg.color = RedHurt;
        StartCoroutine(colorSwap());
        spriteDmg.color = normal;
    }

    public void restoreHealth()
    {
        health += 1;
        spriteDmg.color = GreenHeal;
        StartCoroutine(colorSwap());
        spriteDmg.color = normal;
    }

    public void restartHP()
    {
        health += 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (IN.IsInvincible)
            {

            }

            else
            {
                SoundManager.PlaySound("Getting Hurt");              
                health -= 1;
                IN.ActivateInvulnerability();
                spriteDmg.color = RedHurt;
                StartCoroutine(colorSwap());
                spriteDmg.color = normal;
            }
            KB.KnockBack();

            if (health <= 0)
            {
                restartHP();
                transform.position = GameManager.Instance.lastCheckPointPos;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);           
            }
        }

        if (collision.gameObject.tag == "Boss")
        {

            if (IN.IsInvincible)
            {

            }

            else
            {
                SoundManager.PlaySound("Getting Hurt");
                health -= 1;
                IN.ActivateInvulnerability();
                spriteDmg.color = RedHurt;
                StartCoroutine(colorSwap());
                spriteDmg.color = normal;
               
            }
            KB.KnockBack();

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
            if (IN.IsInvincible)
            {

            }

            else
            {
                SoundManager.PlaySound("Getting Hurt");
                health -= 1;
                IN.ActivateInvulnerability();
                spriteDmg.color = RedHurt;
                StartCoroutine(colorSwap());
                spriteDmg.color = normal;
                
            }
            KB.KnockBack();

            if (health <= 0)
            {
                restartHP();
                transform.position = GameManager.Instance.lastCheckPointPos;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator colorSwap()
    {
        yield return new WaitForSeconds(1);
    }
}
