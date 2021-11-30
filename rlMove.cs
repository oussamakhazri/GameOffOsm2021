using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rlMove : MonoBehaviour
{

    private Vector3 dir = Vector3.left;
    public float speed = 10f;
    //Your Update function
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.position.x <= -10)
        {
            dir = Vector3.right;
        }
        else if (transform.position.x >= 10)
        {
            dir = Vector3.left;
        }
    }
}
