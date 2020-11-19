using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class HollowAndSolid : MonoBehaviour
{
    public void Toggle()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        //Debug.Log("hit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("hit me");
        if (collision.gameObject.tag == "Blaster")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            // Debug.Log("hitting");
            collision.gameObject.SetActive(false);
            collision.GetComponent<Projectile>().DestroyProjectile();
        }    
    }
}
