using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpin : MonoBehaviour
{
    public float xAxis, yAxis, zAxis;

    private void Update()
    {
        transform.Rotate(xAxis, yAxis, zAxis);
    }
}
