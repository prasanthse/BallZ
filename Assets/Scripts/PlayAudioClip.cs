using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClip : MonoBehaviour
{
    public AudioSource soundClip;

    void Start()
    {
        soundClip.GetComponent<AudioSource>();
    }

    public void playSoundClip()
    {
        if (!ThemeMusic.mute)
        {
            soundClip.Play();
        }
    }
}
