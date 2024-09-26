using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public AudioClip firstAudioClip;
    public AudioClip secondAudioClip;
    public AudioSource NarratorGO;

    void Start()
    {
       NarratorGO = GetComponent<AudioSource>();
    }
    public void StartNarrator ()
    {
        NarratorGO.PlayOneShot(firstAudioClip, 0.9f);
        NarratorGO.PlayOneShot(secondAudioClip, 0.5f);
    }
}
