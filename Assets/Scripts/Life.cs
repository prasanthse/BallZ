using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    private Sprite lifeImage, lostImage;
    private Image life1, life2, life3, life4, life5;
    private static int playerLife = 5;
    private Retrieve retrieve;
    private UpdateTables updateTables;

    public Life()
    {
        lifeImage = Resources.Load<Sprite>("Life");
        lostImage = Resources.Load<Sprite>("Out");

        retrieve = new Retrieve();
        updateTables = new UpdateTables();

        updateTables.updateLife("", null, null, null, null);

        life1 = GameObject.FindWithTag("Life1").GetComponent<Image>();
        life2 = GameObject.FindWithTag("Life2").GetComponent<Image>();
        life3 = GameObject.FindWithTag("Life3").GetComponent<Image>();
        life4 = GameObject.FindWithTag("Life4").GetComponent<Image>();
        life5 = GameObject.FindWithTag("Life5").GetComponent<Image>();
    }

    public void IncreaseLife()
    {
        if (playerLife <= 4)
        {
            playerLife += 1;
            ChangeLifeLogo();
        }
    }

    public void decreaseLife()
    {
        if (playerLife > 0)
        {
            getCurrentTime();
            playerLife -= 1;
            ChangeLifeLogo();
        }
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

    private void getCurrentTime()
    {
        Debug.Log(DateTime.Now);
        //Debug.Log(System.DateTime.Now.Year);
        //Debug.Log(System.DateTime.Now.Month);
        //Debug.Log(System.DateTime.Now.Day);
        //Debug.Log(System.DateTime.Now.Hour);
        //Debug.Log(System.DateTime.Now.Minute);
        //Debug.Log(System.DateTime.Now.Second);
        DateTime date = DateTime.Now;
        Debug.Log(date);
    }
}
