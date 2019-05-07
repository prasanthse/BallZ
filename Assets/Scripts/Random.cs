using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour
{
    public float randomNumberGenerator(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}
