﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrckedHole : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        { 
            PlayerDead.isDead = true;

            PlayerDead.x = other.transform.position.x;
            PlayerDead.z = other.transform.position.z;
        }
    }
}
 