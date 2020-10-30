using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTrigger : MonoBehaviour
{
    private Animator anim;
    private Light2D lit;
    private bool turnOnState;

    private void Start()
    {
        anim = GetComponent<Animator>();
        lit = GetComponent<Light2D>();      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (anim.GetBool("Activate"))
            {
                turnOnState = anim.GetBool("Turn On");
                lit.enabled = !lit.enabled;
                anim.SetBool("Turn On", !turnOnState);
            }           
        } 
    }
}
