using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStars : MonoBehaviour
{
    public int createdStars = 0;
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
        Points.currentStars = Points.currentStars + createdStars;
    }
}
