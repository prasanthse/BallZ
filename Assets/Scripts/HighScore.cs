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

    void Start()
    {
        retrieve = new Retrieve();
        highScore.text = "High  Score:  " + retrieve.getHighScore();

        //updateScore = new UpdateScore();

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
            }
        }

        if (highScoreChecking)
        {
            if(playerWinScore > int.Parse(retrieve.getHighScore())){
                highScore.text = "High  Score:  " + playerWinScore;
                //updateScore.updateHighScore(playerWinScore);
            }
        }
    }

    private bool compareScore()
    {
        if(Points.playerPoints > int.Parse(retrieve.getHighScore()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
