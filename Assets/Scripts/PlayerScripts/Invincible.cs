using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    [Header("Invincible")]
    private bool isInvincible = false;
    [SerializeField]
    private float invincibilityDurationSeconds;

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityDurationSeconds);

        isInvincible = false;
    }

    public void MethodThatTriggersInvulnerability()
    {
        if (!isInvincible)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }
}
