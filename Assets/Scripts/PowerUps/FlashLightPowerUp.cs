using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLightPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // collision.gameObject.GetComponent<LightTrigger>().lit = isActiveAndEnabled();  
            // OnCollected.Invoke(this.gameObject);
            Destroy(gameObject);
        }
    }
}
