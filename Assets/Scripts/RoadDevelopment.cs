using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDevelopment : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject path1, path2;
    private GameObject[] pathTypes;
    private int numberOfPaths = 2;
    private Random random;
    private static float selectedPath;
    private int pathsCreated;

    void Start()
    {
        pathTypes = new GameObject[numberOfPaths];

        pathTypes[0] = path1;
        pathTypes[1] = path2;

        random = new Random();
        pathsCreated = 1;
    }

    void Update()
    {
        if (playerTransform.position.z > (200*pathsCreated - 50) && playerTransform.position.z < ((200 * pathsCreated - 50) + 1)) //New path added when the player reached the 3/4 (150) of length of it's current path
        {
            ChangeShapes();
        }

        //destroyPreviousPath();
    }

    private void ChangeShapes()
    {
        selectedPath = random.randomNumberGenerator(0, numberOfPaths);
        Instantiate(pathTypes[(int)selectedPath], new Vector3(0, 0, (200 * pathsCreated + 98)), Quaternion.identity);
        pathsCreated += 1;
    }

    private void destroyPreviousPath()
    {
        if (playerTransform.position.z > (205 * (pathsCreated + 1)) && playerTransform.position.z < ((205 * (pathsCreated + 1)) + 10)) //Delete the previous path when player moves into new path after z position 5
        {
            //Destroy(GameObject.Find("Path(Clone)"));
            GameObject.Find("Path(Clone)").SetActive(false);
        }
    }
}
