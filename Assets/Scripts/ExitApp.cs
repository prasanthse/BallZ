using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitApp : MonoBehaviour
{
    public GameObject exitWindow;
    private Button yes, no;
    private Color color = Color.red;

    void Start()
    {
        yes = GameObject.FindGameObjectWithTag("YesQuit").GetComponent<Button>();
        no = GameObject.FindGameObjectWithTag("NoQuit").GetComponent<Button>();

        exitWindow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
           // Time.timeScale = 0;

            exitWindow.SetActive(true);

            yes.onClick.AddListener(yesQuit);
            no.onClick.AddListener(noQuit);
        }
    }

    private void yesQuit()
    {
        Application.Quit();
    }

    private void noQuit()
    {
        exitWindow.SetActive(false);
    }
}
