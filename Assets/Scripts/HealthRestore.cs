using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().restoreHealth();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(removeObject());
    }

    public IEnumerator removeObject()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
