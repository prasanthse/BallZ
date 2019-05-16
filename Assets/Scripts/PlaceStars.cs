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
    public static bool starPlacement;

    void Start()
    {
        random = new Random();
        createStars = new CreateStars(random);

        starPlacement = false;
    }

    void Update()
    {
        if(!PlayerDead.isDead && !Win.playerWin && !EndLevel.endLevel)
        {
            getStars();
        }

        if (starPlacement)
        {
            createLastStars();
        }
    }

    private void getStars()
    {
        if (playerTransform.position.z > (200 * (NumberOfPaths.pathsCreated - 1) - 40) && playerTransform.position.z < ((200 * (NumberOfPaths.pathsCreated - 1) - 40) + 1)) //New set of stars added when the player reached 160 of length of it's current path
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
            zPosition = random.randomNumberGenerator(zMin + 40, zMin + 200);

            Instantiate(star, new Vector3(xPosition, (float)0.4, zPosition), Quaternion.identity);
        }
    }

    private void createLastStars()
    {
        float x = (float)-0.75;
        int z = (NumberOfPaths.pathsCreated * 200) + 50;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Instantiate(star, new Vector3(x, (float)0.4, z), Quaternion.identity);
                x = x + (float)0.75;
            }

            x = (float)-0.75;
            z = z + 10;
        }

        PlaceStars.starPlacement = false;
    }
}
