using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Sprite soundImage, noSoundImage;
    public Button musicButton;
    private int click;

    void Start()
    {
        click = 0;
    }

    public void changeMusicFactors()
    {
        click = click + 1;
        buttonImage();
    }

    private void buttonImage()
    {
        if (click%2 == 1)
        {
            musicButton.image.overrideSprite = noSoundImage;
        }
        else
        {
            musicButton.image.overrideSprite = soundImage;
        }
    }
}
