using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    public AudioSource bgm;
    public static bool mute = false;
    public static int click = 0;

    void Awake()
    {
        DontDestroyOnLoad(bgm);
    }

    void Update()
    {
        if (mute)
        {
            bgm.Pause();
        }
        else
        {
            bgm.UnPause();
        }
    }
}
