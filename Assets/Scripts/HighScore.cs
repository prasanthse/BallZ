using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScore;
    private Retrieve retrieve;
    private UpdateScore updateScore;
    public static bool highScoreChecking;
    public static int playerWinScore;

    //private Queries queries;

    void Start()
    {
        retrieve = new Retrieve();
        highScore.text = "High  Score:  " + retrieve.getHighScore();
        //updateScore = new UpdateScore();

        //queries = new Queries();
        //highScore.text = "High  Score:  " + queries.getHighScore();

        highScoreChecking = false;
        playerWinScore = 0;
    }

    void Update()
    {
        if (compareScore())
        {
            highScore.text = "High  Score:  " + Points.playerPoints;

            if(PlayerDead.isDead)
            {
                //updateScore.updateHighScore(Points.playerPoints);
                //queries.updateHighScore(Points.playerPoints);
                Debug.Log("dead");
            }
        }

        if (highScoreChecking)
        {
            if (playerWinScore > int.Parse(retrieve.getHighScore()))
            {
                highScore.text = "High  Score:  " + playerWinScore;
                //updateScore.updateHighScore(playerWinScore);
            }

            //if (playerWinScore > int.Parse(queries.getHighScore()))
            //{
            //    highScore.text = "High  Score:  " + playerWinScore;
            //    //queries.updateHighScore(playerWinScore);
            //}
        }
    }

    private bool compareScore()
    {
        if (Points.playerPoints > int.Parse(retrieve.getHighScore()))
        {
            return true;
        }
        else
        {
            return false;
        }

        //if (Points.playerPoints > int.Parse(queries.getHighScore()))
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }
}
