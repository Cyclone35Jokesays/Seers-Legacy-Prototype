using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class HollowAndSolid : MonoBehaviour
{
    public void Toggle()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blaster")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            //StartCoroutine(SolidCoroutine());
            collision.gameObject.SetActive(false);
            collision.GetComponent<OtherProjectile>().DestroyProjectile();
            collision.GetComponent<Projectile>().DestroyProjectile();
        }    
    }

    IEnumerator SolidCoroutine()
    {
        yield return new WaitForSeconds(4);
    }
}
