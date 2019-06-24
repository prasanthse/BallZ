using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    private float timeInterval = 10;

    //CalculateTime
    public void checkTimeSlots(string life, string columnName)
    {
        if (int.Parse(seperateSeconds(life)) < (60 - timeInterval) && int.Parse(seperateSeconds(life)) > timeInterval)
        {
            Database.column = columnName;
            Database.lostTime = "Need Update";
        }
        else if(int.Parse(seperateSeconds(life)) < (60 - timeInterval))
        {
            Debug.Log("need to implement");

        }else if (int.Parse(seperateSeconds(life)) > timeInterval)
        {
            Debug.Log("need to implement");
        }
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
