using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDevelopment : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        if(playerTransform.position.z - transform.position.z > 100)
        {
            transform.Translate(new Vector3(0, 0, 200));
            //ChangeShapes();
        }
    }

    /*private void ChangeShapes()
    {

    }*/

}
