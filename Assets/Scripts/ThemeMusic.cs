using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    public AudioSource bgm;
    public static bool mute = false;
    public static int click = 0;

    public static ThemeMusic instance = null;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(bgm);
        }

        DontDestroyOnLoad(bgm);
    }

    void Update()
    {
        if (bgm != null)
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
}
