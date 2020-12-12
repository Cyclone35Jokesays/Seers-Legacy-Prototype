using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemy : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float stoppingDistance;
    [SerializeField]
    public float retreatDistance;
    private Transform player;

    private float timeBtwShots;
    [SerializeField]
    public float startTimeBtwShots;

    [SerializeField]
    public GameObject projectile;

    [SerializeField]
    public float agroRange;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
        timeBtwShots = startTimeBtwShots;
    }


    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroRange)
        {   
            ChasePlayer();
        }

        else if(distToPlayer != agroRange)
        {    
            StopChasingPlayer();
            speed = 3f;
        }
    }

    public void ChasePlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }

        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            SoundManager.PlaySound("EnemyShot");
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void StopChasingPlayer()
    {
        speed = 0f;
    }
}
