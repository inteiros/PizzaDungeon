using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endAudio : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    public AudioClip win;
    void Start()
    {
        sfxSource.volume = 0.7f;
        sfxSource.PlayOneShot(win);
    }
}
