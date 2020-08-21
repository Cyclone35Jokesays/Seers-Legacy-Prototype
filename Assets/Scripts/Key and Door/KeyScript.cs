using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private KeyType keyType;

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
