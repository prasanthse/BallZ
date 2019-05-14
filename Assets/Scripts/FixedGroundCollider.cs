using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedGroundCollider : MonoBehaviour
{
    public BoxCollider fixedGroundCollider;

    void Start()
    {
        fixedGroundCollider.size = (new Vector3(Screen.width, 1, 300)); 
    }
}
