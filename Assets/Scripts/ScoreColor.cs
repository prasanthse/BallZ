using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreColor : MonoBehaviour
{
    public Text score;
    public static bool scoreColor = false;

    void Update()
    {
        if (scoreColor)
        {
            score.color = Color.green;
        }
        else
        {
            if (Points.playerPoints < Points.totalPoints / 2)
            {
                score.color = Color.red;
            }
            else if (Points.playerPoints < Points.totalPoints * 0.9)
            {
                score.color = Color.yellow;
            }
            else if (Points.playerPoints >= Points.totalPoints * 0.9)
            {
                score.color = Color.green;
            }
        }
    }
}
