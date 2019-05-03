using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDevelopment : MonoBehaviour
{
    public Transform playerTransform;
    private GameObject[] pathShapes;
    private int roadCount = 5;
    private int zPosition;
    private int loopCount;

    void Start()
    {
        zPosition = 200;
        pathShapes = new GameObject[roadCount];
        
        for(loopCount = 0; loopCount < roadCount; loopCount++)
        {
            pathShapes[loopCount] = GameObject.FindGameObjectWithTag("Path1");
        }

        loopCount = 0;
    }

    void Update()
    {
        if(playerTransform.position.z - transform.position.z > 100)
        {
            transform.Translate(new Vector3(0, 0, zPosition));
            //ChangeShapes();
            //zPosition = zPosition + 200;
        }
    }

    private void ChangeShapes()
    {

    }

}
