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

    [SerializeField]
    public Vector2 direction;

    [SerializeField]
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
                SoundManager.PlaySound("Explode");
            }

            else if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.GetComponent<ghostBossBehaviour>().TakeDamage(damage);
                //hitInfo.collider.GetComponent<BossEnemy>().TakeDamage(damage);
                SoundManager.PlaySound("Explode");
            }

            else if (hitInfo.collider.CompareTag("FlyingBoss"))
            {
                hitInfo.collider.GetComponent<FlyingEnemyCount>().TakeDamage(damage);
                SoundManager.PlaySound("Explode");
            }

            DestroyProjectile();
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);      
    }
}
