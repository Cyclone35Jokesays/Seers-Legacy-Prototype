using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerTarget : MonoBehaviour
{
    [SerializeField]
    private float timeBtwShots;
    [SerializeField]
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
