using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip RunningSound, JumpSound, FireSound, DeathSound;
    static AudioSource audioSrc;

    private static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        RunningSound = Resources.Load<AudioClip>("Running");
        JumpSound = Resources.Load<AudioClip>("Jump");
        FireSound = Resources.Load<AudioClip>("Blaster");
        DeathSound = Resources.Load<AudioClip>("Explode");

        audioSrc = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Blaster":
                audioSrc.PlayOneShot(FireSound);
                break;
            case "Running":
                audioSrc.PlayOneShot(RunningSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "Explode":
                audioSrc.PlayOneShot(DeathSound);
                break;
        }
    }
}
