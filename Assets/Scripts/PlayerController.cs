using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text counting;
    public float time;
    public float speed;
    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
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
        }
    }

    private void playerMovement()
    {
        transform.Rotate(Vector3.forward, 100);
        transform.Translate(new Vector3(0, 0, 1) * speed);
    }

    private void inputAccelaration()
    {
        
    }
}
