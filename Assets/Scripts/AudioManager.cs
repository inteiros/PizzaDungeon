using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource sfxSource2;

    private bool isWalkingPlaying = false;
    private bool isRunningPlaying = false;

    public AudioClip background;
    public AudioClip walk;
    public AudioClip run;
    public AudioClip jump;
    public AudioClip ratdeath;
    public AudioClip death;
    void Start()
    {
        musicSource.clip = background;
        musicSource.volume = 0.3f;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.volume = 1.3f;
        sfxSource.PlayOneShot(clip);
    }

    public void PlayWalkingSFX()
    {
        if (!isWalkingPlaying)
        {
            sfxSource2.clip = walk;
            sfxSource2.loop = true;
            sfxSource2.volume = 1;
            isWalkingPlaying = true;
            sfxSource2.Play();
        }
    }

    public void PlayRunningSFX()
    {
        if (!isRunningPlaying)
        {
            sfxSource2.clip = run;
            sfxSource2.loop = true;
            sfxSource2.volume = 1.3f;
            isRunningPlaying = true;
            sfxSource2.Play();
        }
    }

    public void StopSFX()
    {
         sfxSource2.Stop();
         isWalkingPlaying = false;
         isRunningPlaying = false;
    }
}
