using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    private float timeInterval;

    void Start()
    {
        timeInterval = 15; //Minutes
    }

    void Update()
    {
        if (!DatabaseUpdates.life1.Equals("null"))
        {
            checkTimeSlots(DatabaseUpdates.life1);
        }
    }

    public void checkTimeSlots(string life)
    {
        if (seperateYear(life).Equals(DateTime.Now.Year) && seperateMonth(life).Equals(DateTime.Now.Month) && seperateDay(life).Equals(DateTime.Now.Day) &&
            seperateHour(life).Equals(DateTime.Now.Hour))
        {
            if (int.Parse(seperateMinutes(life)) < (60 - timeInterval))
            {
                if (DateTime.Now.Minute == (int.Parse(seperateMinutes(life)) + timeInterval))
                {
                    updateDatabase("life_One");
                }
            }else if (int.Parse(seperateMinutes(life)) == (60 - timeInterval))
            {
                if (DateTime.Now.Minute == 0)
                {
                    updateDatabase("life_One");
                }
            }
            else
            {
                Debug.Log("need to done");
            }
        }
    }


    private string getCurrentTime()
    {
        return DateTime.Now.ToString();
    }

    //private bool lifeCountDown()
    //{
    //    //if (startTimer < timeInterval)
    //    //{
    //    //    startTimer = startTimer + Time.deltaTime;
    //    //    return true;
    //    //}
    //    //else
    //    //{
    //    //    return false;
    //    //}
    //}

    private void updateDatabase(string column)
    {
        Database.column = column;
        Database.increase = true;
        Database.lostTime = "null";
    }


    //Seperate Times
    private string seperateTimeWithoutTags(string life)
    {
        string timeWithTags = life.Substring(life.IndexOf(' ') + 1); //Time with AM or PM
        return getTextBeforeIndex(timeWithTags, " ");
    }

    private string seperateSeconds(string life)
    {
        string t1 = getTextAfterCharacter(seperateTimeWithoutTags(life), ':');
        return getTextAfterCharacter(t1, ':');
    }

    private string seperateMinutes(string life)
    {
        string t1 = seperateTimeWithoutTags(life).Substring(seperateTimeWithoutTags(life).IndexOf(':') + 1);
        return getTextBeforeIndex(t1, ":");
    }

    private string seperateHour(string life)
    {
        return getTextBeforeIndex(seperateTimeWithoutTags(life), ":");
    }

    private string seperateTimeTags(string life)
    {
        string timeWithTags = life.Substring(life.IndexOf(' ') + 1); //Time with AM or PM
        string timeTags = timeWithTags.Substring(timeWithTags.IndexOf(' ') + 1); //Time Tags which is AM or PM

        return timeTags;
    }



    //Seperate Dates
    private string seperateDate(string life)
    {
        return getTextBeforeIndex(life, " ");
    }

    private string seperateYear(string life)
    {
        string d1 = getTextAfterCharacter(seperateDate(life), '/');
        return getTextAfterCharacter(d1, '/');
    }

    private string seperateMonth(string life)
    {
        string t1 = seperateDate(life).Substring(seperateDate(life).IndexOf('/') + 1);
        return getTextBeforeIndex(t1, "/");
    }

    private string seperateDay(string life)
    {
        return getTextBeforeIndex(seperateDate(life), "/");
    }




    //Common functions for seperate Times and Dates
    private int getIndex(string text, string character)
    {
        int index = text.IndexOf(character);
        return index;
    }

    private string getTextBeforeIndex(string text, string character)
    {
        string text2 = null;

        if (getIndex(text, character) > 0)
        {
            text2 = text.Substring(0, getIndex(text, character));
        }

        return text2;
    }

    private string getTextAfterCharacter(string text, char character)
    {
        return text.Substring(text.IndexOf(character) + 1);
    }
}
