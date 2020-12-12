using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float lifeTime;

    private Transform player;
    private Vector2 target;
    public LayerMask hitting;
    public Vector2 direction;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
        target = new Vector2(player.position.x, player.position.y);
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

            else if (hitInfo.collider.CompareTag("Untagged"))
            {
                DestroyProjectile();
            }

            DestroyProjectile();
        }


        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((hitting.value & 1<<collision.gameObject.layer) != 0)
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
