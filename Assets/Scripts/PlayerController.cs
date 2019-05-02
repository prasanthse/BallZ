using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed);
       // getPhoneAccelaration();
    }

    private void getPhoneAccelaration()
    {
        Vector3 tilt = Input.acceleration;
        tilt = Quaternion.Euler(90, 0, 0) * tilt;
        rigid.AddForce(tilt);
    }
}
