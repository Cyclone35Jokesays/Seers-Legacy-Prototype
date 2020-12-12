using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialCollectable : MonoBehaviour
{
    private float coin = 0;
    public Text textCoins;
   // private Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            SoundManager.PlaySound("Spawn");
            //anim.SetBool("Hit", true);
            coin++;
            textCoins.text = coin.ToString();
            Destroy(collision.gameObject);
        }
    }
}
