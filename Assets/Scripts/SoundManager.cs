using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip RunningSound, JumpSound, FireSound, DeathSound;
    static AudioSource audioSrc;

    void Start()
    {
        RunningSound = Resources.Load<AudioClip>("Running");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
