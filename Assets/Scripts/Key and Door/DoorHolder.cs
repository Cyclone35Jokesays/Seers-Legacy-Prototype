using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorHolder : MonoBehaviour, ICollectible
{
    [SerializeField]
    private KeyScript.KeyType keyType;
    private Vector2 loc;

    public event Action<GameObject> OnCollected;

    public KeyScript.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
