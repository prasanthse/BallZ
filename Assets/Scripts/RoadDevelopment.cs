﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDevelopment : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject path1, path2, star, lastPath;
    private GameObject[] pathTypes;
    private int numberOfPaths = 2;
    private Random random;
    private static float selectedPath;
    private int lastPathPosition;
    private static int getLastPathIndex;

    void Start()
    {
        pathTypes = new GameObject[numberOfPaths];

        pathTypes[0] = path1;
        pathTypes[1] = path2;

        random = new Random();

        lastPathPosition = 0;
        getLastPathIndex = 0;
    }

    void Update()
    {
        if (playerTransform.position.z > (200*NumberOfPaths.pathsCreated - 150) && playerTransform.position.z < ((200 * NumberOfPaths.pathsCreated - 150) + 1) && !PlayerDead.isDead && !Win.playerWin && !EndLevel.endLevel) //New path added when the player reached the 3/4 (150) of length of it's current path
        {
            ChangeShapes();
        }

        if (Win.playerWin)
        {
            createLastPath();
        }

        if (lastPathPosition != 0)
        {
            if (playerTransform.position.z > lastPathPosition + 50)
            {
                PlayerController.slowMotion = true;
            }
        }
    }

    private void ChangeShapes()
    {
        selectedPath = random.randomNumberGenerator(0, numberOfPaths);
        Instantiate(pathTypes[(int)selectedPath], new Vector3(0, 0, (200 * NumberOfPaths.pathsCreated + 98)), Quaternion.identity);

        //if((int)selectedPath == 0)
        //{
        //    Instantiate(pathTypes[(int)selectedPath], new Vector3(0, 0, (200 * NumberOfPaths.pathsCreated + 98)), Quaternion.identity);
        //    //getLastPathIndex = 0;
        //}
        //else if((int)selectedPath == 1)
        //{
        //    Instantiate(pathTypes[(int)selectedPath], new Vector3(1.6F, 0, (200 * NumberOfPaths.pathsCreated + 27.73F)), Quaternion.identity);
        //    //getLastPathIndex = 1;
        //}

        NumberOfPaths.calculatePathCount();
    }

    private void createLastPath()
    {
        lastPathPosition = calculateLastPathZPositon();

        Instantiate(lastPath, new Vector3(0, 0, lastPathPosition), Quaternion.identity);

        Win.playerWin = false;

        HighScore.playerWinScore = Points.playerPoints;

        Points.playerPoints = 0;
        Points.currentStars = 0;
    }

    private int calculateLastPathZPositon()
    {
        int z = (NumberOfPaths.pathsCreated * 200) + 98;
        return z;
    }
}
