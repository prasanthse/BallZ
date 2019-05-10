using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    private float x = 0;
    private float y = (float)0.5; //-4

    public void adjustColliderSize(BoxCollider ground, float playerPositionZ)
    {
        ground.center = new Vector3(x, y, playerPositionZ);
    }
}
