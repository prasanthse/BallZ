using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRock : MonoBehaviour
{
    public GameObject lavaRock;
    public Transform player;
    public float time;
    private Random random;
    private int numberOfRocks;

    void Start()
    {
        random = new Random();
        numberOfRocks = 0;
    }

    void Update()
    {

        if (time >= 0)
        {
            time = time - Time.deltaTime;
        }
        else
        {
            dropLavaRocks();
        }
        
    }

    private void dropLavaRocks()
    {
        Instantiate(lavaRock, new Vector3((int)random.randomNumberGenerator(-Screen.width/2, Screen.width/2), (int)random.randomNumberGenerator(10, 50), (int)random.randomNumberGenerator(player.position.z, player.position.z + 200)), Quaternion.identity);
    }

}
