using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static bool playerWin;

    void Start()
    {
        playerWin = false;
    }

    void Update()
    {
        if (!PlayerDead.isDead)
        {
            comparePoints();
        }
    }

    private void comparePoints()
    {
        if(GeneratedAllTotalStars())
        {
            if(Points.playerPoints >= Points.totalPoints * 0.9)
            {
                playerWin = true;
                GameOver.winTextDisplay = true;
                OnTrigger.bravo = true;
                PlaceStars.starPlacement = true;
                EndLevel.endLevel = true;
                ScoreColor.scoreColor = true;
                HighScore.highScoreChecking = true;
            }   
        }
    }

    public bool GeneratedAllTotalStars()
    {
        if (Points.currentStars >= Points.totalPoints)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
