using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text counting;
    public float time;
    public float speed;
    public AudioSource holeSound;
    public GameObject gameOver;
    private Rigidbody rigid;
    private bool movement;
    private Life life;
    private Camera gameView;
    public static bool slowMotion;

    void Start()
    {
        SetVariableToDeafault();

        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        movement = true;

        life = new Life();

        gameOver.SetActive(false);

        gameView = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        life.lifeCountDown();

        if (time >= 0)
        {
            time = time - Time.deltaTime;
            counting.text = "" + (int)time;
        }
        else
        {
            counting.text = "";

            if (!ExitApp.pause)
            {
                if (movement)
                {
                    playerMovement();
                }

                if (PlayerDead.isDead && movement)
                {
                    SetPlayerDead();
                }

                if (slowMotion)
                {
                    createSlowMotionEffect();
                }
            }
        }
    }

    private void playerMovement()
    {
        float dirX = Input.acceleration.x;

        transform.Rotate(speed * 100, 0, 0, Space.Self);
        transform.Translate(dirX * (3 * speed/4), 0, speed, Space.World);

        if (transform.position.x > 1.6875 || transform.position.x < -1.6875)
        {
            rigid.isKinematic = false;

            PlayerDead.isDead = true;

            PlayerDead.x = transform.position.x;
            PlayerDead.z = transform.position.z;
        }
        else
        {
            rigid.isKinematic = true;
        }
    }

    private void SetPlayerDead()
    {
        if (!ThemeMusic.mute)
        {
            holeSound.Play();
        }

        transform.Rotate(0, 0, 0, Space.Self);
        transform.Translate(PlayerDead.x, -1, PlayerDead.z, Space.World);

        movement = false;

        life.decreaseLife();

        gameOver.SetActive(true);
    }

    float timer = 2;

    private void createSlowMotionEffect()
    {
        if (timer >= 0)
        {
            timer = timer - Time.deltaTime;
        }
        else
        {
            gameOver.SetActive(true);
            movement = false;
        }
    }

    private void SetVariableToDeafault()
    {
        Win.playerWin = false;
        EndLevel.endLevel = false;
        GameOver.winTextDisplay = false;
        OnTrigger.bravo = false;
        ScoreColor.scoreColor = false;
        NumberOfPaths.pathsCreated = 1;
        PlayerDead.isDead = false;
        HighScore.highScoreChecking = false;
        LevelSelection.locked = true;
        ExitApp.pause = false;
        slowMotion = false;
    }
}
