using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeadTrue : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController.PlayerDead();
    }
}
