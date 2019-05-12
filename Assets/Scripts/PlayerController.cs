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
    private Rigidbody rigid;

    void Start()
    {
        isDead = false;

        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
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
            playerMovement();

            if (PlayerDead.isDead)
            {
                SetPlayerDead();
            }
        }
    }

    private void playerMovement()
    {
        float dirX = Input.acceleration.x;

        transform.Rotate(0, 0, 100);
        transform.Translate(dirX * (3 * speed/4), 0, speed);

        if (transform.position.x > 1.5 || transform.position.x < -1.5)
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
        rigid.isKinematic = false;
        transform.Translate(PlayerDead.x, -5, PlayerDead.z);
        transform.Rotate(0, 0, 0);
        rigid.velocity = Vector3.zero;
    }
}
