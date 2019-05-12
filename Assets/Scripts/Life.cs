using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Sprite lifeImage, lostImage;
    public Image life1, life2, life3, life4, life5;
    private static int playerLife = 5;

    public void IncreaseLife()
    {
        playerLife += 1;
        ChangeLifeLogo();
    }

    public void ChangeLifeLogo()
    {
        switch (playerLife)
        {
            case 0:
                life1.sprite = lostImage;
                life2.sprite = lostImage;
                life3.sprite = lostImage;
                life4.sprite = lostImage;
                life5.sprite = lostImage;
                return;
            case 1:
                life1.sprite = lostImage;
                life2.sprite = lostImage;
                life3.sprite = lostImage;
                life4.sprite = lostImage;
                life5.sprite = lifeImage;
                return;
            case 2:
                life1.sprite = lostImage;
                life2.sprite = lostImage;
                life3.sprite = lostImage;
                life4.sprite = lifeImage;
                life5.sprite = lifeImage;
                return;
            case 3:
                life1.sprite = lostImage;
                life2.sprite = lostImage;
                life3.sprite = lifeImage;
                life4.sprite = lifeImage;
                life5.sprite = lifeImage;
                return;
            case 4:
                life1.sprite = lostImage;
                life2.sprite = lifeImage;
                life3.sprite = lifeImage;
                life4.sprite = lifeImage;
                life5.sprite = lifeImage;
                return;
            case 5:
                life1.sprite = lifeImage;
                life2.sprite = lifeImage;
                life3.sprite = lifeImage;
                life4.sprite = lifeImage;
                life5.sprite = lifeImage;
                return;
            default:
                Debug.Log("Error in life logo changing");
                break;
        }
    }
}
