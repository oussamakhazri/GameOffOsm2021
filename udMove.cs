using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class udMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 dir = Vector3.up;
    public float speed = 6f;
    //Your Update function
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.position.y <= 3)
        {
            dir = Vector3.up;
        }
        else if (transform.position.y >= 12)
        {
            dir = Vector3.down;
        }
    }
}
