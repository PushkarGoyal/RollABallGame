using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNz : MonoBehaviour
{

    private int speed = 5;
    private bool direction = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            transform.position += new Vector3(0.0f, 0.0f, speed * Time.deltaTime);
        }

        if (transform.position.z > 3.50f)
            direction = false;
        if (!direction)
        {
            transform.position += new Vector3(0.0f, 0.0f, -speed * Time.deltaTime);
        }
        if (transform.position.z < -7.9f)
            direction = true;
    }
}
