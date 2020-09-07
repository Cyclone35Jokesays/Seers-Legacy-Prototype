using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] float distance;
    public int damage;
    public LayerMask whatIsSolid;

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
