using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject block;
    public GameObject block2;
    public GameObject Boss;

    public void SettingTrue()
    {
        block.gameObject.SetActive(true);
        block2.gameObject.SetActive(true);
        Boss.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SettingTrue();
            gameObject.SetActive(false);
        }      
    }
}
