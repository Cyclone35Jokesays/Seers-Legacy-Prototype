using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerTarget : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    private void Start()
    {        
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {      
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
