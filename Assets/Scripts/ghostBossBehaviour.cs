using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBossBehaviour : MonoBehaviour
{
    [SerializeField]
    public int health;
    [SerializeField]
    public GameObject deathEffect;
    public GameObject Health;
    private PlayerController pc;
    public GameObject block1;
    public GameObject block2;
    public GameObject CamSwitch;

    private void Start()
    {
        pc = GameManager.Instance.GetComponent<PlayerController>();
        StartCoroutine(makeSound());
    }

    private void Update()
    {
        if (health <= 0)
        {
            SoundManager.PlaySound("EnemyDeath");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(Health, transform.position, Quaternion.identity);
            Destroy(gameObject);
            block1.gameObject.SetActive(false);
            block2.gameObject.SetActive(false);
            CamSwitch.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    IEnumerator makeSound()
    {
        SoundManager.PlaySound("Spirit");
        yield return new WaitForSeconds(11);
    }
}
