using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    private static Sprite lifeImage, lostImage;
    private static Image life1, life2, life3, life4, life5;

    public Life()
    {
        lifeImage = Resources.Load<Sprite>("Life");
        lostImage = Resources.Load<Sprite>("Out");

        life1 = GameObject.FindWithTag("Life1").GetComponent<Image>();
        life2 = GameObject.FindWithTag("Life2").GetComponent<Image>();
        life3 = GameObject.FindWithTag("Life3").GetComponent<Image>();
        life4 = GameObject.FindWithTag("Life4").GetComponent<Image>();
        life5 = GameObject.FindWithTag("Life5").GetComponent<Image>();

        setLifeIcons();
    }

    private void setLifeIcons()
    {
        if (DatabaseUpdates.life1.Equals("null"))
        {
            life1.sprite = lifeImage;
        }
        else
        {
            life1.sprite = lostImage;
        }

        if (DatabaseUpdates.life2.Equals("null"))
        {
            life2.sprite = lifeImage;
        }
        else
        {
            life2.sprite = lostImage;
        }

        if (DatabaseUpdates.life3.Equals("null"))
        {
            life3.sprite = lifeImage;
        }
        else
        {
            life3.sprite = lostImage;
        }

        if (DatabaseUpdates.life4.Equals("null"))
        {
            life4.sprite = lifeImage;
        }
        else
        {
            life4.sprite = lostImage;
        }

        if (DatabaseUpdates.life5.Equals("null"))
        {
            life5.sprite = lifeImage;
        }
        else
        {
            life5.sprite = lostImage;
        }
    }

    public void decreaseLife()
    {
        if (DatabaseUpdates.life5.Equals("null"))
        {
            if (!DatabaseUpdates.life4.Equals("null"))
            {
                Database.column = "life_Five";
                Database.lostTime = getCurrentTime();
                life5.sprite = lostImage;
            }
            else if (!DatabaseUpdates.life3.Equals("null"))
            {
                Database.column = "life_Four";
                Database.lostTime = getCurrentTime();
                life4.sprite = lostImage;
            }
            else if (!DatabaseUpdates.life2.Equals("null"))
            {
                Database.column = "life_Three";
                Database.lostTime = getCurrentTime();
                life3.sprite = lostImage;
            }
            else if (!DatabaseUpdates.life1.Equals("null"))
            {
                Database.column = "life_Two";
                Database.lostTime = getCurrentTime();
                life2.sprite = lostImage;
            }
            else
            {
                Database.column = "life_One";
                Database.lostTime = getCurrentTime();
                life1.sprite = lostImage;
            }
        }
        else
        {
            if (DatabaseUpdates.life1.Equals("null"))
            {
                Database.column = "life_One";
                Database.lostTime = getCurrentTime();
                life1.sprite = lostImage;
            }
            else if (DatabaseUpdates.life2.Equals("null"))
            {
                Database.column = "life_Two";
                Database.lostTime = getCurrentTime();
                life2.sprite = lostImage;
            }
            else if (DatabaseUpdates.life3.Equals("null"))
            {
                Database.column = "life_Three";
                Database.lostTime = getCurrentTime();
                life3.sprite = lostImage;
            }
            else if (DatabaseUpdates.life4.Equals("null"))
            {
                Database.column = "life_Four";
                Database.lostTime = getCurrentTime();
                life4.sprite = lostImage;
            }
        }
    }

    private string getCurrentTime()
    {
        return DateTime.Now.ToString();
    }

    public static void setRuntimeIcon(string life)
    {
        switch (life)
        {
            case "life_One":
                life1.sprite = lifeImage;
                break;

            case "life_Two":
                life2.sprite = lifeImage;
                break;

            case "life_Three":
                life3.sprite = lifeImage;
                break;

            case "life_Four":
                life4.sprite = lifeImage;
                break;

            case "life_Five":
                life5.sprite = lifeImage;
                break;
        }
    }
}
