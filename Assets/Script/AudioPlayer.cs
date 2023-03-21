using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;


    public void Play(AudioClip audioClip)
    {

        audioSource.clip = audioClip;
        audioSource.Play();
       
    }

    public void PlayLater(AudioClip audioClip, double audioTimer)
    {
        audioSource.clip = audioClip;
        audioSource.PlayScheduled( audioTimer);

    }

    public void PauseAudio()
    {
        audioSource.Pause();
        Time.timeScale = 0;
    }

    public void ResumeAudio()
    {
        audioSource.UnPause();
        Time.timeScale = 1;
    }
}

