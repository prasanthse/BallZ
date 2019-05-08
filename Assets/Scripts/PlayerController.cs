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
            //dirX = Input.acceleration.x * speed;
            //dirY = Input.acceleration.y * speed;

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
        transform.Rotate(Vector3.forward, 100);
        transform.Translate(new Vector3(0, 0, 1) * speed);
    }

    public static void PlayerDead()
    {
        isDead = true;
    }
}
