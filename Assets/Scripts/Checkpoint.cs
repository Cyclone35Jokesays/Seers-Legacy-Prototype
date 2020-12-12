using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController myPlayer = other.GetComponent<PlayerController>();
            Health playerHealth = other.GetComponent<Health>();
            
            GameManager.Instance.lastCheckPointPos = transform.position;
            GameManager.Instance.sectionName = SceneManager.GetActiveScene().name;
            Debug.Log(GameManager.Instance.sectionName);

            GameManager.Instance.SaveData(myPlayer.extraJumpValue,

                myPlayer.LightObject.GetComponent<Light2D>().enabled,

                myPlayer.solidHollowObject.turnSolid,

                myPlayer.blaster.trip,

                playerHealth.numOfHearts);
        }
    }
}
