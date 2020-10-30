using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float lifeTime;
    [SerializeField]
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    public GameObject barrier;
    public GameObject tar;

    public Vector2 direction;

    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }

            if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.GetComponent<BossEnemy>().TakeDamage(damage);
            }

            if (hitInfo.collider.CompareTag("FlyingBoss"))
            {
                hitInfo.collider.GetComponent<FlyingEnemyCount>().TakeDamage(damage);
            }

            if (hitInfo.collider.CompareTag("Target"))
            {
                hitInfo.collider.GetComponent<TargetBlock>().DoTask();
            }

            DestroyProjectile();
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
       
        SoundManager.PlaySound("Explode");      
    }
}
