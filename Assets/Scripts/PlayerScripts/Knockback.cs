using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [Header("KnockBack")]
    [SerializeField]
    private bool applyKnockback;
    [SerializeField]
    private float knockbackSpeedX, knockbackSpeedY, knockbackDuration;
    private bool knockback;
    private float knockbackStart;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void KnockBack()
    {
        knockback = true;
        knockbackStart = Time.time;
        rb.velocity = new Vector2(knockbackSpeedX, knockbackSpeedY);
    }

    public void CheckKnockback()
    {
        if (Time.time >= knockbackStart + knockbackDuration && knockback)
        {
            knockback = false;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
    }
}
