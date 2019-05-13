using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text counting;
    public float time;
    public float speed;
    public static bool isDead;
    public AudioSource holeSound;
    public GameObject gameOver;
    private Rigidbody rigid;
    private bool movement;
    private Life life;

    void Start()
    {
        isDead = false;

        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        movement = true;

        life = new Life();

        gameOver.SetActive(false);
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
}
