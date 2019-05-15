using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreColor : MonoBehaviour
{
    public Text score;

    void Update()
    {
        if (Points.playerPoints < Points.totalPoints / 2)
        {
            score.color = Color.red;
        }
        else if (Points.playerPoints < Points.totalPoints * 0.9)
        {
            score.color = Color.yellow;
        }
        else
        {
            score.color = Color.green;
        }
    }
}
