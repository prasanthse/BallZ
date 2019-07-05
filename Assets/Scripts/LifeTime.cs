using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTime : MonoBehaviour
{
    private float timeInterval;
    private bool timeUpdates;
    public GameObject noLife;
    public Text countDownText;
    private int min;

    void Start()
    {
        timeInterval = 15; //Minutes
        timeUpdates = true;
        noLife.SetActive(false);
        min = 0;
    }

    void Update()
    {
        if (!(DatabaseUpdates.life1.Equals("null") || DatabaseUpdates.life2.Equals("null") || DatabaseUpdates.life3.Equals("null") || DatabaseUpdates.life4.Equals("null") ||
            DatabaseUpdates.life5.Equals("null")))
        {
            noLife.SetActive(true);
            displayRemainingMinute();
        }
        else
        {
            noLife.SetActive(false);
        }

        if (!DatabaseUpdates.life1.Equals("null"))
        {
            timeUpdates = true;
            checkTimeSlots(DatabaseUpdates.life1, "life_One");
        }

        if (!DatabaseUpdates.life2.Equals("null"))
        {
            timeUpdates = true;
            checkTimeSlots(DatabaseUpdates.life2, "life_Two");
        }

        if (!DatabaseUpdates.life3.Equals("null"))
        {
            timeUpdates = true;
            checkTimeSlots(DatabaseUpdates.life3, "life_Three");
        }

        if (!DatabaseUpdates.life4.Equals("null"))
        {
            timeUpdates = true;
            checkTimeSlots(DatabaseUpdates.life4, "life_Four");
        }

        if (!DatabaseUpdates.life5.Equals("null"))
        {
            timeUpdates = true;
            checkTimeSlots(DatabaseUpdates.life5, "life_Five");
        }
    }

    public void checkTimeSlots(string life, string column)
    {
        int yearDb = int.Parse(seperateYear(life));
        int monthDb = int.Parse(seperateDay(life));
        int dayDb = int.Parse(seperateMonth(life));
        int hourDb = int.Parse(seperateHour(life));
        int minuteDb = int.Parse(seperateMinutes(life));
        int secondDb = int.Parse(seperateSeconds(life));
        string tagDb = seperateTimeTags(life);

        int secondNow = DateTime.Now.Second;
        int minuteNow = DateTime.Now.Minute;
        int hourNow = DateTime.Now.Hour;
        int dayNow = DateTime.Now.Day;
        int monthNow = DateTime.Now.Month;
        int yearNow = DateTime.Now.Year;
        string tagNow = seperateTimeTags(DateTime.Now.ToString());

        if (tagNow.Equals("PM"))
        {
            hourNow = hourNow - 12;
        }

        //Year substraction greater than zero
        if (timeUpdates && yearNow - yearDb > 0)
        {
            updateDatabase(column);
            timeUpdates = false;
        }
        //Year substraction equals to zero
        else if (timeUpdates && yearNow - yearDb == 0)
        {
            //Month substraction greater than zero
            if (timeUpdates && monthNow - monthDb > 0)
            {
                updateDatabase(column);
                timeUpdates = false;
            }
            //Month substraction equals to zero
            else if (timeUpdates && monthNow - monthDb == 0)
            {
                //day substraction greater than zero
                if (timeUpdates && dayNow - dayDb > 0)
                {
                    updateDatabase(column);
                    timeUpdates = false;
                }
                //day substraction equals to zero
                else if (timeUpdates && dayNow - dayDb == 0)
                {
                    //Hour substraction greater than zero
                    if(timeUpdates && hourNow - hourDb > 0)
                    {
                        updateDatabase(column);
                        timeUpdates = false;
                    }
                    //Hour substraction equals to zero
                    else if (timeUpdates && hourNow - hourDb == 0)
                    {
                        //Minutes substraction greater than or equals to timeInterval without tag change
                        if (timeUpdates && minuteNow - minuteDb >= timeInterval && tagNow.Equals(tagDb))
                        {
                            updateDatabase(column);
                            timeUpdates = false;
                        }
                        //Minutes substraction less than or equals to timeInterval with tag change
                        else if (timeUpdates && !tagNow.Equals(tagDb))
                        {
                            if (timeUpdates && (60 - minuteDb + minuteNow) >= timeInterval)
                            {
                                updateDatabase(column);
                                timeUpdates = false;
                            }
                        }
                    }
                    //Hour substraction less than zero
                    else if (timeUpdates && hourNow - hourDb < 0)
                    {
                        updateDatabase(column);
                        timeUpdates = false;
                    }
                }
            }
        }
    }


    private string getCurrentTime()
    {
        return DateTime.Now.ToString();
    }

    private void checkMinutes(int count, string column)
    {
        if (count >= timeInterval)
        {
            timeUpdates = false;
        }
        else
        {
            timeUpdates = true;
        }

        if (!timeUpdates)
        {
            updateDatabase(column);
        }
    }

    private void updateDatabase(string column)
    {
        Database.column = column;
        Database.increase = true;
        Database.lostTime = "null";
        Life.setRuntimeIcon(column);
    }

    private void displayRemainingMinute()
    {
        countDownText.text = "" + (int.Parse(seperateMinutes(DatabaseUpdates.life1)) - DateTime.Now.Minute);
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
