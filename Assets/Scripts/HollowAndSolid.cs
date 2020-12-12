using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class HollowAndSolid : MonoBehaviour
{
    private Color blue = new Color(0, 136, 255);
    private Color orange = new Color(255, 155, 0);

    private Light2D thisLight;

    private void Start()
    {
        thisLight = GetComponent<Light2D>();
    }

    public void Toggle()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        thisLight.color = blue;
        gameObject.layer = 0;
        StopAllCoroutines();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blaster")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            StartCoroutine(SolidCoroutine());
            collision.gameObject.SetActive(false);
            collision.GetComponent<OtherProjectile>().DestroyProjectile();
            gameObject.layer = 8;
            thisLight.color = orange;
        }

        else
        {
            collision.GetComponent<Projectile>().DestroyProjectile();
        }
    }

    IEnumerator SolidCoroutine()
    {
        yield return new WaitForSeconds(5);
        Toggle();
    }
}
