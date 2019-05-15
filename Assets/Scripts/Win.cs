using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static bool playerWin = false;
    
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
            }   
        }
    }

    public bool GeneratedAllTotalStars()
    {
        if (Points.currentStars == 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
