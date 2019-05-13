using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStars : MonoBehaviour
{
    public int createdStars = 0;
    public int totalStars = 0;
    private Random random;

    public CreateStars(Random random)
    {
        this.random = random;
    }

    public int createRandomStars()
    {
        createdStars = (int)random.randomNumberGenerator(1, 6);
        calculateTotalStars();
        return createdStars;
    }

    private void calculateTotalStars()
    {
        totalStars = totalStars + createdStars;
    }

    public int returnTotalStars()
    {
        return totalStars;
    }

    public bool starLimitation()
    {
        if(totalStars <= Points.totalPoints - 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
