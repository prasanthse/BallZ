using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfPaths : MonoBehaviour
{
    public static int pathsCreated = 1;

    public static void calculatePathCount()
    {
        pathsCreated += 1;
    }
}
