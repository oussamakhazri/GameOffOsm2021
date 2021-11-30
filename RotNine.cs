using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotNine : MonoBehaviour
{

    public float speed = 5f;
    Rigidbody2D rb;
    public float xAngle, yAngle, zAngle;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        }
    }


}


