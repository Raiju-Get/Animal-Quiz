using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")][Tooltip("Place your audio sources here")]
    
    [SerializeField] AudioSource gameMusic;
    [SerializeField] List<AudioSource> gameSound = new List<AudioSource>();
    public  bool isSoundPlayer;
    public bool isMusicPlayer;

    private void Awake()
    {
        gameMusic = FindObjectOfType<MusicPlayer>().MusicSource;
    }


    private void Start()
    {
       
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENINGAUDIO", 1) == 1)
        {
            PlayerPrefs.SetInt("FIRSTTIMEOPENINGAUDIO", 0);
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            if (PlayerPrefs.GetInt("Sound")!=1)
            {
                SoundArrayMute(true);
            }
            else
            {
                SoundArrayMute(false);
            }
            if (PlayerPrefs.GetInt("Music") != 1)
            {
                GameMute(true);
            }
            else
            {
                GameMute(false);
            }
        }
        DebugSound();
    }

    private void GameMute(bool state)
    {
        isMusicPlayer= state;
        gameMusic.mute = state;
    }

    private void DebugSound()
    {
        Debug.Log(PlayerPrefs.GetInt("Music"));
        Debug.Log(PlayerPrefs.GetInt("Sound"));
    }

    private void SoundArrayMute(bool state)
    {
        isSoundPlayer= state;
        for (int i = 0; i < gameSound.Count; i++)
        {
            gameSound[i].mute = state;
        }
    }

    public void ChangeSound()
    {
      
        if (isSoundPlayer)
        {
            isSoundPlayer = false;
            PlayerPrefs.SetInt("Sound", 1);
            for (int i = 0; i < gameSound.Count; i++)
            {
                gameSound[i].mute = isSoundPlayer;
            }
               
                
                
        }
        else
        {
            isSoundPlayer = true;
            PlayerPrefs.SetInt("Sound", 0);
            for (int i = 0; i < gameSound.Count; i++)
            {
                gameSound[i].mute = isSoundPlayer;
            }

        }
        

        DebugSound();
    }

    public void ChangeMusic()
    {

        if (isMusicPlayer)
        {
            isMusicPlayer = false;
            PlayerPrefs.SetInt("Music", 1);
            gameMusic.mute = isMusicPlayer;
            
        }
        else
        {
            isMusicPlayer = true;
            PlayerPrefs.SetInt("Music", 0);
            
            gameMusic.mute = isMusicPlayer;
           
        }
        DebugSound();
    }

 
}


