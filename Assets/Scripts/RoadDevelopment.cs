using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDevelopment : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject path1, path2, star;
    private GameObject[] pathTypes;
    private int numberOfPaths = 2;
    private Random random;
    private CreateStars createStars;
    private static float selectedPath;
    private int pathsCreated;

    void Start()
    {
        pathTypes = new GameObject[numberOfPaths];

        pathTypes[0] = path1;
        pathTypes[1] = path2;

        random = new Random();
        createStars = new CreateStars(random);

        pathsCreated = 1;
    }

    void Update()
    {
        if (playerTransform.position.z > (200*pathsCreated - 50) && playerTransform.position.z < ((200 * pathsCreated - 50) + 1)) //New path added when the player reached the 3/4 (150) of length of it's current path
        {
            ChangeShapes();
        }

        /*if ((playerTransform.position.z > 400) && (playerTransform.position.z > ((200 * (pathsCreated - 2)) + 205) && playerTransform.position.z < ((200 * (pathsCreated - 2)) + 206))) //Delete the previous path when player moves into new path after z position 5
        {
            Debug.Log("delete");
        }*/
    }

    private void ChangeShapes()
    {
        selectedPath = random.randomNumberGenerator(0, numberOfPaths);
        Instantiate(pathTypes[(int)selectedPath], new Vector3(0, 0, (200 * pathsCreated + 98)), Quaternion.identity);
        pathsCreated += 1;

        placeStars();
    }

    private void placeStars()
    {
        //Debug.Log("Number of stars: " + createStars.createRandomStars());

        float xPosition = 0;
        float zPosition = 0;
        float zMin = 200 * (pathsCreated - 1);

        for (int i = 0; i < createStars.createRandomStars(); i++)
        {
            //Debug.Log("Star Number: " + i);

            xPosition = random.randomNumberGenerator((float)-1.4, (float)1.4);
            zPosition = random.randomNumberGenerator(zMin, zMin + 200);

            Instantiate(star, new Vector3(xPosition, (float)0.4, zPosition), Quaternion.identity);
        }
    }
}
