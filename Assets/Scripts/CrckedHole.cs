using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrckedHole : MonoBehaviour
{
    public AudioSource holeSound;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Hole"))
        {
            PlayerController.PlayerDead();
            holeSound.Play();
        }
    }
}
