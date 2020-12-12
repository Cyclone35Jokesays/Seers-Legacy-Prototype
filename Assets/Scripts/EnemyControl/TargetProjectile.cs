using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProjectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float lifeTime;

    private Transform player;
    public LayerMask hitting;
    public Vector2 direction;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, lifeTime, hitting);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<Health>().takeDamage();
            }

            DestroyProjectile();
        }
       // transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((hitting.value & 1 << collision.gameObject.layer) != 0)
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
