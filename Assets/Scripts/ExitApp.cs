using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitApp : MonoBehaviour
{
    public GameObject exitWindow;
    public bool mainMenu = false;
    public bool game = false;
    public static bool pause = false;
    private Button yes, no;

    private Camera camera;

    void Start()
    {
        yes = GameObject.FindGameObjectWithTag("YesQuit").GetComponent<Button>();
        no = GameObject.FindGameObjectWithTag("NoQuit").GetComponent<Button>();

        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        exitWindow.SetActive(false);
        camera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            if (mainMenu || game)
            {
                camera.enabled = false;

                if (game)
                {
                    GamePause();
                }

                exitWindow.SetActive(true);

                yes.onClick.AddListener(yesQuit);
                no.onClick.AddListener(noQuit);

            }else
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
        camera.enabled = true;
        exitWindow.SetActive(false);
        pause = false;
        Time.timeScale = 1;
    }

    private void GamePause()
    {
        pause = true;
        Time.timeScale = 0;
    }
}
