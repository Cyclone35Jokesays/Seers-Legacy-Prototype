using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip RunningSound, JumpSound, FireSound, DeathSound, HurtSound, CollectSound, MessageSound, ExplodeSound, SpiritSound, AttackSound, GrowlSound;
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
        HurtSound = Resources.Load<AudioClip>("Getting Hurt");
        CollectSound = Resources.Load<AudioClip>("Spawn");
        MessageSound = Resources.Load<AudioClip>("Gust");
        ExplodeSound = Resources.Load<AudioClip>("Explosion");
        SpiritSound = Resources.Load<AudioClip>("Spirit");
        AttackSound = Resources.Load<AudioClip>("EnemyShot");
        GrowlSound = Resources.Load<AudioClip>("Growl");

        audioSrc = GetComponent<AudioSource>();
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
            case "Getting Hurt":
                audioSrc.PlayOneShot(HurtSound);
                break;
            case "Spawn":
                audioSrc.PlayOneShot(CollectSound);
                break;
            case "Gust":
                audioSrc.PlayOneShot(MessageSound);
                break;
            case "Explosion":
                audioSrc.PlayOneShot(ExplodeSound);
                break;
            case "Spirit":
                audioSrc.PlayOneShot(SpiritSound);
                break;
            case "EnemyShot":
                audioSrc.PlayOneShot(AttackSound);
                break;
            case "Growl":
                audioSrc.PlayOneShot(GrowlSound);
                break;
        }
    }
}
