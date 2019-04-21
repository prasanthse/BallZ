using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectSocialMedias : MonoBehaviour{

    public void connectMyFb(){
        Application.OpenURL("https://www.facebook.com/profile.php?id=100005272362325");
    }

    public void connectMyLinkedIn(){
        Application.OpenURL("https://www.linkedin.com/in/prasanthse1996/");
    }

}
