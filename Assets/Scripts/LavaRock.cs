using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRock : MonoBehaviour
{
    public GameObject lavaRock;
    public Transform player;
    public float time;
    public BoxCollider ground;
    public float timeBetweenLavaRocks = 3;

    private Random random;
    private int numberOfRocks;
    private GroundCollider groundCollider;

    private float currentTime = 0;

    private float x = Screen.width;
    private float y = 1;
    private float z = 200;

    void Start()
    {
        random = new Random();
        groundCollider = new GroundCollider();
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
            if (!PlayerDead.isDead)
            {
                dropLavaRocks();
                ground.size = new Vector3(x, y, player.position.z * 2);
            }
        }

    }

    private void dropLavaRocks()
    {
        currentTime += Time.deltaTime;
        
        if(currentTime >= timeBetweenLavaRocks)
        {
            currentTime = 0;
            Instantiate(lavaRock, new Vector3((int)random.randomNumberGenerator(-Screen.width / 2, Screen.width / 2), (int)random.randomNumberGenerator(25, 50), (int)random.randomNumberGenerator(player.position.z, player.position.z + 200)), Quaternion.identity);
        }
    }

}
