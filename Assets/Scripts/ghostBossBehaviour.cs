using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBossBehaviour : MonoBehaviour
{
    [Header("Normal")]
    [SerializeField]
    public int health;
    [SerializeField]
    public GameObject deathEffect;
    [SerializeField]
    public GameObject Health;
    private PlayerController pc;
    public GameObject block1;
    public GameObject block2;
    public GameObject CamSwitch;

    [Header("Shooting")]
    private float timeBtwShots;
    [SerializeField]
    public float startTimeBtwShots;
    [SerializeField]
    public GameObject Shot1;
    [SerializeField]
    public GameObject Shot2;
    [SerializeField]
    public GameObject Shot3;
    [SerializeField]
    public GameObject Shot4;

    private void Start()
    {
        pc = GameManager.Instance.GetComponent<PlayerController>();
        StartCoroutine(makeSound());
        timeBtwShots = startTimeBtwShots;
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

        if (timeBtwShots <= 0)
        {
            SoundManager.PlaySound("EnemyShot");
            Instantiate(Shot1, transform.position, Quaternion.identity);
            Instantiate(Shot2, transform.position, Quaternion.identity);
            Instantiate(Shot3, transform.position, Quaternion.identity);
            Instantiate(Shot4, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
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
