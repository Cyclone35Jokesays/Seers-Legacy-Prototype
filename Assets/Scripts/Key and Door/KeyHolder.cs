using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;

    private List<KeyScript.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<KeyScript.KeyType>();
    }

    public List<KeyScript.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(KeyScript.KeyType keyType)
    {
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(KeyScript.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(KeyScript.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        KeyScript key = collision.GetComponent<KeyScript>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        DoorHolder keyDoor = collision.GetComponent<DoorHolder>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();               
            }
        }
    }
}
