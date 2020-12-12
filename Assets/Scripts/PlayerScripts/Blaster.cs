using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField]
    public float offSet;
    public GameObject projectile1;
    public GameObject projectile2;
    public GameObject projectile3;
    public Transform shotPoint;
    public bool trip = false;

    public GameObject turnSolidProjectile;
    public bool turnSolid = false;

    private float timeBtwShots;
    [SerializeField]
    public float startTimeBtwShots;
    public float startTimeBtwShots2;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offSet);
        
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile1, shotPoint.position, transform.rotation);
                triple();
                timeBtwShots = startTimeBtwShots;
                SoundManager.PlaySound("Blaster");
            }

            if (turnSolid == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Instantiate(turnSolidProjectile, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots2;
                    SoundManager.PlaySound("Blaster");
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void triple()
    {
        if (trip == true)
        {
            Instantiate(projectile2, shotPoint.position, transform.rotation);
            Instantiate(projectile3, shotPoint.position, transform.rotation);
        }
    }
}
