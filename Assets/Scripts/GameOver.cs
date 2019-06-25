using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text win, lost, total, playerPoints, youWin, highestPoints;
    public Button decision, exit;
    public float time;
    public static bool winTextDisplay;

    void Start()
    {
        youWin.GetComponent<Text>().enabled = false;
        setTitleText(false, false);

        setPoints();

        exit.onClick.AddListener(changeSceneToMenu);

        setButton("Retry");
        decision.onClick.AddListener(retry);

        winTextDisplay = false;

        highestPoints.text = DatabaseUpdates.highScore;
    }

    void Update()
    {
        setPoints();

        if (PlayerDead.isDead)
        {
            setTitleText(true, false);
        }

        if (winTextDisplay)
        {
            if (time >= 0)
            {
                time = time - Time.deltaTime;
                youWin.GetComponent<Text>().enabled = true;
            }
            else
            {
                winTextDisplay = false;
                youWin.GetComponent<Text>().enabled = false;
            }

            setTitleText(false, true);
            setButton("Next");
        }
    }

    private void setPoints()
    {
        total.text = Points.totalPoints.ToString();

        if (HighScore.highScoreChecking)
        {
            playerPoints.text = HighScore.playerWinScore.ToString();
        }
        else
        {
            playerPoints.text = Points.playerPoints.ToString();
        }
    }

    private void setTitleText(bool lostText, bool winText)
    {
        lost.GetComponent<Text>().enabled = lostText;
        win.GetComponent<Text>().enabled = winText;
    }

    private void setButton(string decisionWord)
    {
        decision.GetComponentInChildren<Text>().text = decisionWord;

        if (decisionWord.Equals("Retry"))
        {
            decision.onClick.AddListener(retry);
        }
        else if (decisionWord.Equals("Next"))
        {
            LevelSelection.locked = false;
            decision.onClick.AddListener(changeSceneNext);
        }
    }
    
    private void changeSceneToMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void changeSceneNext()
    {
        SceneManager.LoadScene(4);
    }

    private void retry()
    {
        SceneManager.LoadScene(5);
    }
}
