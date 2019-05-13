using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text win, lost, total, playerPoints;
    public Button decision, exit;

    private void Start()
    {
        setTitleText(false, false);
        setPoints();
        exit.onClick.AddListener(changeScene);
        setButtonText("Retry");
    }

    void Update()
    {
        setPoints();

        if (PlayerDead.isDead)
        {
            setTitleText(true, false);
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
            Debug.Log("retry");
            //SceneManager.LoadScene(5);
        }
        else if (decisionWord.Equals("next"))
        {
            SceneManager.LoadScene(4);
        }
    }

    private void changeScene()
    {
        SceneManager.LoadScene(4);
    }
}
