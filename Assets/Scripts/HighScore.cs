using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScore;

    public static bool highScoreChecking;
    public static int playerWinScore;

    void Start()
    {
        highScore.text = "High  Score:  " + DatabaseUpdates.highScore;

        highScoreChecking = false;
        playerWinScore = 0;
    }

    void Update()
    {
        if (compareScore())
        {
            highScore.text = "High  Score:  " + Points.playerPoints;

            if (PlayerDead.isDead && Database.changeHighScore)
            {
                Database.selectHighScore = "dead";
                Database.updateScoreConfirm = true;
            }
        }

        if (highScoreChecking)
        {
            if ((playerWinScore > int.Parse(DatabaseUpdates.highScore)) && Database.changeHighScore)
            {
                highScore.text = "High  Score:  " + playerWinScore;
                Database.selectHighScore = "win";
                Database.updateScoreConfirm = true;
            }
        }
    }

    private bool compareScore()
    {
        if (Points.playerPoints > int.Parse(DatabaseUpdates.highScore))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
