using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLightPowerUp : MonoBehaviour
{
    LightTrigger lit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SetTrue();
           
            // OnCollected.Invoke(this.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetTrue()
    {
       lit.gameObject.SetActive(true);
        //  enemy.gameObject.SetActive(true);
    }
}
