using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    [Header("Invincible")]
    private bool isInvincible = false;
    private bool isOnCooldown = false;
    [SerializeField]
    private float invincibilityCooldownSeconds;
    [SerializeField]
    private float invincibilityDurationSeconds;
   
    public bool IsInvincible { get { return isInvincible; } }
    
    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDurationSeconds);

        isInvincible = false;
        StartInvincibilityCooldown();    
    }

    private IEnumerator StartInvincibilityCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(invincibilityCooldownSeconds);
        isOnCooldown = false;
    }

    public void ActivateInvulnerability()
    {
        if (!isInvincible && !isOnCooldown)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }
}
