using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHolder : MonoBehaviour
{
    [SerializeField]
    private KeyScript.KeyType keyType;

    public KeyScript.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
