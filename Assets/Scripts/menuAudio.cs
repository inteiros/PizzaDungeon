using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip background;
    public AudioClip start;
    public AudioClip quit;
    void Start()
    {
        musicSource.clip = background;
        musicSource.volume = 0.3f;
        musicSource.Play();
    }

    public void PlayStart()
    {
        sfxSource.volume = 1;
        sfxSource.PlayOneShot(start);
    }

    public void PlayQuit()
    {
        sfxSource.volume = 1;
        sfxSource.PlayOneShot(quit);
    }
}
