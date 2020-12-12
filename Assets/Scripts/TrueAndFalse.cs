using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueAndFalse : MonoBehaviour
{
    [SerializeField]
    public GameObject block;
    [SerializeField]
    public GameObject block2;

    public void SettingTrue()
    {
        block.gameObject.SetActive(true);
        block2.gameObject.SetActive(false);
    
    }

    public void SettingFalse()
    {
        block.gameObject.SetActive(false);
        block2.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SettingTrue();
        }

        else
        {
            SettingFalse();
        }
    }
}
