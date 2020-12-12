using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private Transform pc;

    [SerializeField]
    public float agroRange;
    private Health hp;
    public GameObject explode;

    private void Start()
    {
        pc = GameManager.Instance.player.transform;
        hp = GameManager.Instance.player.GetComponent<Health>();
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, pc.position);
        if (distToPlayer < agroRange)
        {
            hp.takeDamage();
            SoundManager.PlaySound("Getting Hurt");
            SoundManager.PlaySound("Explosion");
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else if (distToPlayer != agroRange)
        {

        }
    }
}
