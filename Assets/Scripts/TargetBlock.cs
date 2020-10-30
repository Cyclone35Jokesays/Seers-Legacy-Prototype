using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlock : MonoBehaviour
{
    public GameObject block;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blaster")
        {
            DoTask();
        }

        else
        {
            DontTask();
        }
    }

    public void DoTask()
    {  
        block.SetActive(false);
    }

    public void DontTask()
    {
        block.SetActive(true);
    }
}
