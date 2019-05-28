using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Sprite soundImage, noSoundImage;
    public Button musicButton;

    void Start()
    {
        buttonImage();
    }

    public void changeMusicFactors()
    {
        ThemeMusic.click = ThemeMusic.click + 1;
        buttonImage();
    }

    private void buttonImage()
    {
        if (ThemeMusic.click %2 == 1)
        {
            ThemeMusic.mute = true;
            musicButton.image.overrideSprite = noSoundImage;
        }
        else
        {
            ThemeMusic.mute = false;
            musicButton.image.overrideSprite = soundImage;
        }
    }
}
