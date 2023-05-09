using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossdiagonal : MonoBehaviour
{

    private bool direction = true;
    private int speed = 7;
    private float mov = 0.9f;
    private float movn = -0.9f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void move()
    {
        if (direction)
            transform.localPosition += new Vector3(0.0f, 0.0f, movn * speed * Time.deltaTime);
        if (transform.localPosition.z < -2.5f)
            direction = false;
        if (!direction)
        {
            transform.localPosition += new Vector3(0.0f, 0.0f, mov * speed * Time.deltaTime);
        }

        if (transform.localPosition.z > 1.8f)
            direction = true;
    }


    // Update is called once per frame
    void Update()
    {
        move();
    }
}
