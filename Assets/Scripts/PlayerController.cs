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
        Win.playerWin = false;
        EndLevel.endLevel = false;
        GameOver.winTextDisplay = false;
        OnTrigger.bravo = false;
        ScoreColor.scoreColor = false;
        NumberOfPaths.pathsCreated = 1;
        PlayerDead.isDead = false;
        slowMotion = false;

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
        if(time >= 0)
        {
            time = time - Time.deltaTime;
            counting.text = "" + (int)time;
        }
        else
        {
            counting.text = "";

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

    private void playerMovement()
    {
        float dirX = Input.acceleration.x;

        //transform.Rotate(10, 0, 0);
        transform.Translate(dirX * (3 * speed/4), 0, speed);

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
        holeSound.Play();

        transform.Translate(PlayerDead.x, -1, PlayerDead.z);
        //transform.Rotate(0, 0, 0);

        movement = false;

        life.decreaseLife();

        gameOver.SetActive(true);
    }

    float timer = 5;

    private void createSlowMotionEffect()
    {
        if (timer >= 0)
        {
            timer = timer - Time.deltaTime;
            //Time.timeScale = (float)0.5;
        }
        else
        {
            movement = false;
        }
    }
}
