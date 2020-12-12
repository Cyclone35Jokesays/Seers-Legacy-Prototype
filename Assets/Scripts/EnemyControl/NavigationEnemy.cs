using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationEnemy : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    public float speed;
    private float waitTime;
    [SerializeField]
    public float startWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private Transform player;

    [Header("Blaster")]
    private float timeBtwShots;
    [SerializeField]
    public float startTimeBtwShots;
    [SerializeField]
    public GameObject projectile1;
    [SerializeField]
    public GameObject projectile2;
    [SerializeField]
    public GameObject projectile3;
    [SerializeField]
    public GameObject projectile4;

    [SerializeField]
    public float agroRange;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.02f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroRange)
        {
            if (timeBtwShots <= 0)
            {
                SoundManager.PlaySound("EnemyShot");
                Instantiate(projectile1, transform.position, Quaternion.identity);
                Instantiate(projectile2, transform.position, Quaternion.identity);
                Instantiate(projectile3, transform.position, Quaternion.identity);
                Instantiate(projectile4, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }

            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

        else if (distToPlayer != agroRange)
        {
            
        }
    }
}
