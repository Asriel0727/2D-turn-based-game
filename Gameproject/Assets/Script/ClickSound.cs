using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    public AudioClip clickSound;

    private Button button;
    private AudioSource audioSource;

    private void Start()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = clickSound;

        button.onClick.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        audioSource.Play();
    }
}
