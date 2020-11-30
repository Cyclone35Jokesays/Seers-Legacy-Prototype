using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherProjectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float lifeTime;
    [SerializeField]
    public float distance;
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
            if (hitInfo.collider.CompareTag("Barrier"))
            {
                hitInfo.collider.GetComponent<HollowAndSolid>().Toggle();
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
