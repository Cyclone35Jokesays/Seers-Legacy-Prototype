using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransistions : MonoBehaviour
{
    private static MusicTransistions instance;

    [SerializeField]
    public AudioSource track1;
    [SerializeField]
    public AudioSource track2;
    [SerializeField]
    public AudioSource track3;

    [SerializeField]
    public int trackSelector;
    [SerializeField]
    public int trackHistory;

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

    private void Start()
    {
        trackSelector = Random.Range(0, 3);
        if (trackSelector == 0)
        {
            track1.Play();
            trackHistory = 1;
        }
        else if (trackSelector == 1)
        {
            track2.Play();
            trackHistory = 2;
        }
        else if (trackSelector == 2)
        {
            track3.Play();
            trackHistory = 3;
        }
    }

    private void Update()
    {
        if (track1.isPlaying == false && track2.isPlaying == false && track3.isPlaying == false)
        {
            trackSelector = Random.Range(0, 3);
            if (trackSelector == 0 && trackHistory != 1)
            {
                track1.Play();
                trackHistory = 1;
            }
            else if (trackSelector == 1 && trackHistory != 2)
            {
                track2.Play();
                trackHistory = 2;
            }
            else if (trackSelector == 2 && trackHistory != 3)
            {
                track3.Play();
                trackHistory = 3;
            }
        }
    }
}
