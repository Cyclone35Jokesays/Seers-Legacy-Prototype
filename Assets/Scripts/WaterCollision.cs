using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    private Health damage;
    private PlayerController play;

    private void Start()
    {
        play = GameManager.Instance.player.GetComponent<PlayerController>();
        damage = GameManager.Instance.player.GetComponent<Health>();
    }
}
