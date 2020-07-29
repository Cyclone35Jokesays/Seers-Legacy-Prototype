using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProjectile : MonoBehaviour
{
    public float speed;

    private Transform obj;
    private Vector2 target;

    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Target").transform;
        target = new Vector2(obj.position.x, obj.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            DestroyProjectile();
        }

        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
