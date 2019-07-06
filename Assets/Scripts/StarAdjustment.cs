using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAdjustment : MonoBehaviour
{
    public Transform star1, star2, star3, star4, star5;
    private Random random;

    void Start()
    {
        random = new Random();
        setHorizontalPosition();
    }

    private void setHorizontalPosition()
    {
        star1.Translate(random.randomNumberGenerator(-1.5F, 1.5F), 0.4F, random.randomNumberGenerator(0, 25));
        star2.Translate(random.randomNumberGenerator(-1.5F, 1.5F), 0.4F, random.randomNumberGenerator(0, 25));
        star3.Translate(random.randomNumberGenerator(-1.5F, 1.5F), 0.4F, random.randomNumberGenerator(0, 25));
        star4.Translate(random.randomNumberGenerator(-1.5F, 1.5F), 0.4F, random.randomNumberGenerator(0, 25));
        star5.Translate(random.randomNumberGenerator(-1.5F, 1.5F), 0.4F, random.randomNumberGenerator(0, 25));
    }
}
