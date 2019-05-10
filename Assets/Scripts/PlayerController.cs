using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text counting;
    public float time;
    public float speed;
    public static bool moveAllowed = true;
    public static bool isDead;
    private Rigidbody rigid;
    //private Animator animator;
    //float dirX, dirY;

    void Start()
    {
        isDead = false;

        rigid = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();

        //animator.SetBool("BallDead", isDead);

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

            /*if (isDead)
            {
                animator.SetBool("BallDead", isDead);
            }*/
        }
    }

    /*void FixedUpdate()
    {
        if (moveAllowed)
        {
            rigid.velocity = new Vector2(rigid.velocity.x + dirX, rigid.velocity.y + dirY);
        }
    }*/

    private void playerMovement()
    {
        float dirX = Input.acceleration.x;

        //transform.Rotate(100, 0, 0);
        transform.Translate(dirX * (3 * speed/4), 0, speed);
    }

    public static void PlayerDead()
    {
        isDead = true;
    }
}
