using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyScript : MonoBehaviour, ICollectible
{
    [SerializeField]
    private KeyType keyType;
    public event Action<GameObject> OnCollected;
    private Vector2 loc;

    private void Update()
    {
        
    }

    public enum KeyType
    {
        Red, Green, Blue
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
    }
}
