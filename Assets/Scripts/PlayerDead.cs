using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private static float x, y, z;

    public void MakePlayerDead(Transform player)
    {
        x = player.position.x;
        z = player.position.z;
    }

    public static Vector3 ApplyDead()
    {
        return new Vector3(x, -4, z);
    }
}
