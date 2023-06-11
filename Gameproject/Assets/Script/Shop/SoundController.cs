using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public AudioClip sound1;
    public AudioClip sound2;

    private void Start()
    {
        audioSource1.clip = sound1;
        audioSource2.clip = sound2;
    }

    public void PlaySound1()
    {
        audioSource2.Stop();

        audioSource1.Play();
    }

    public void PlaySound2()
    {
        audioSource1.Stop();

        audioSource2.Play();
    }
}
