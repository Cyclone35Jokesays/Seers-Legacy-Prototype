using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject block;
    public GameObject enemy;

  
    public void SettingTrue()
    {
        block.gameObject.SetActive(true);
        enemy.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SettingTrue();
            Destroy(gameObject);
        }      
    }
}
