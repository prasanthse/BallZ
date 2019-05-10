using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitApp : MonoBehaviour
{
    public GameObject exitWindow;
    public bool mainMenu = false;
    private Button yes, no;

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
            if (mainMenu)
            {
                exitWindow.SetActive(true);

                yes.onClick.AddListener(yesQuit);
                no.onClick.AddListener(noQuit);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
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
