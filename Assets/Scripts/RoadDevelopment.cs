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
    private static float selectedPath;

    void Start()
    {
        pathTypes = new GameObject[numberOfPaths];

        pathTypes[0] = path1;
        pathTypes[1] = path2;

        random = new Random();
    }

    void Update()
    {
        if (playerTransform.position.z > (200*NumberOfPaths.pathsCreated - 50) && playerTransform.position.z < ((200 * NumberOfPaths.pathsCreated - 50) + 1) && !PlayerDead.isDead) //New path added when the player reached the 3/4 (150) of length of it's current path
        {
            ChangeShapes();
        }
    }

    private void ChangeShapes()
    {
        selectedPath = random.randomNumberGenerator(0, numberOfPaths);
        Instantiate(pathTypes[(int)selectedPath], new Vector3(0, 0, (200 * NumberOfPaths.pathsCreated + 98)), Quaternion.identity);
        NumberOfPaths.calculatePathCount();
    }
}
