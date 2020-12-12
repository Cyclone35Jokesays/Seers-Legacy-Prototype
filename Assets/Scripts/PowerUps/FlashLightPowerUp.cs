using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightPowerUp : MonoBehaviour
{
    GameObject lit;

    private void Start()
    {
       // lit = FindObjectOfType<LightTrigger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("Spawn");
            lit = collision.gameObject.GetComponent<PlayerController>().LightObject;
            lit.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
