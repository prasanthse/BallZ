using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceStars : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject star;
    private CreateStars createStars;
    private Random random;
    private float currentTime = 0;
    private float timeBetweenStars = 5;

    void Start()
    {
        random = new Random();
        createStars = new CreateStars(random);
    }

    void Update()
    {
        if(playerTransform.position.z >= 200 && !PlayerDead.isDead)
        {
            getStars();
        }
    }

    private void getStars()
    {
        if (playerTransform.position.z > (200 * NumberOfPaths.pathsCreated - 50) && playerTransform.position.z < ((200 * NumberOfPaths.pathsCreated - 50) + 1))
        {
            placeStars();
        }
    }

    private void placeStars()
    {
        int starsGenerated = createStars.createRandomStars();

        float xPosition = 0;
        float zPosition = 0;
        float zMin = playerTransform.position.z;

        for (int i = 0; i < starsGenerated; i++)
        {
            xPosition = random.randomNumberGenerator((float)-1.4, (float)1.4);
            zPosition = random.randomNumberGenerator(zMin + 50, zMin + 200);

            Instantiate(star, new Vector3(xPosition, (float)0.4, zPosition), Quaternion.identity);
        }
    }
}
