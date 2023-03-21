using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteSwitch : MonoBehaviour
{
    public enum MusicType
    {
        Music,
        Sound
    }

    [SerializeField] Sprite firstSprite;
    [SerializeField] Sprite secondSprite;
    [SerializeField] Image buttonImage;
    bool isPressed = false;
    public MusicType thisType;

    public void Awake()
    {
        if (isPressed)
        {
            IsPressedNow();
        }
        else
        {
            IsNotPressedNow();
        }
    }

    public void IsNotPressedNow()
    {
        buttonImage.sprite = firstSprite;
        isPressed = true;
    }

    public void IsPressedNow()
    {
        buttonImage.sprite = secondSprite;
        isPressed = false;
    }

    private void Start()
    {
        switch (thisType)
        {
            case MusicType.Music:
                if (PlayerPrefs.GetInt("Music") != 1)
                {
                    IsPressedNow();
                }
                else
                {
                    IsNotPressedNow();
                }
                break;
            case MusicType.Sound:
                if (PlayerPrefs.GetInt("Sound") != 1)
                {
                    IsPressedNow();
                }
                else
                {
                    IsNotPressedNow();
                }
                break;
            default:
                break;
        }
    }
}
