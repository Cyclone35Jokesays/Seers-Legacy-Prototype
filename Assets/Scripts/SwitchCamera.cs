using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    public GameObject camSwitch;
    public CinemachineVirtualCamera cam;


    private void SettingTrue()
    {

        cam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        cam.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
        camSwitch.gameObject.SetActive(true);
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
