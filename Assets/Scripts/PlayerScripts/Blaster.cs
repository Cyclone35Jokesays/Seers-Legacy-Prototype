using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public float offSet;
    public GameObject projectile1;
    public GameObject projectile2;
    public GameObject projectile3;
    public Transform shotPoint;
    public bool trip = false;

    private float timeBtwShots;
    public float startTimeBtwShots;

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
