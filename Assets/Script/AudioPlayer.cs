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
}

