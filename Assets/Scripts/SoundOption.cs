using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour{
    
    private static bool mute = false;
    private GameObject soundIcon;
    public Button soundButton;

    private void Start(){
        soundButton = GetComponent<Button>();
        soundIcon = GetComponent<GameObject>();
    }

    public void changeSoundIcon(){

        if (mute == true){
            mute = false;
        }
        else{
            mute = true;
        }

        if (mute){
            soundIcon = GameObject.Find("Assets/Images/audio-volume.png");
        }
        else{
            soundIcon = GameObject.Find("Assets/Images/audio-volume-mute.png");
        }
        //soundButton.GetComponent<Image>().color = soundIcon;
    }

}
