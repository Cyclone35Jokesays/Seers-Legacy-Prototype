using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
    }

    private void Awake()
    {
        
    }
}
