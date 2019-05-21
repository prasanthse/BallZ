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
    private Retrieve retrieve;

    private void Start()
    {
        youWin.GetComponent<Text>().enabled = false;
        setTitleText(false, false);
        setPoints();
        exit.onClick.AddListener(changeScene);
        setButtonText("Retry");
        winTextDisplay = false;

        retrieve = new Retrieve();
        highestPoints.text = retrieve.getHighScore();
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
            setButtonText("Next");
        }
    }

    private void setPoints()
    {
        total.text = Points.totalPoints.ToString();
        playerPoints.text = Points.playerPoints.ToString();
    }

    private void setTitleText(bool lostText, bool winText)
    {
        lost.GetComponent<Text>().enabled = lostText;
        win.GetComponent<Text>().enabled = winText;
    }

    private void setButtonText(string decisionWord)
    {
        decision.GetComponentInChildren<Text>().text = decisionWord;

        if (decisionWord.Equals("Retry"))
        {
            decision.onClick.AddListener(retry);
        }
        else if (decisionWord.Equals("Next"))
        {
            decision.onClick.AddListener(changeScene);
        }
    }

    private void changeScene()
    {
        SceneManager.LoadScene(4);
    }

    private void retry()
    {
        SceneManager.LoadScene(5);
    }
}
