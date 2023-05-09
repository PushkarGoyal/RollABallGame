using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{

    private int speed = 7;
    private float movX = 0.9f;
    private float movnX = -0.9f;
    private bool direction = true;

    //private float movnX = -0.9f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void left()
    {
        if (direction)
            transform.position += new Vector3(movnX * speed * Time.deltaTime, 0.0f, 0.0f);
        if (transform.position.x > -5.5f)
            direction = false;
        if (!direction)
            transform.position += new Vector3(movX * speed * Time.deltaTime, 0.0f, 0.0f);
        if (transform.position.x > 6.0f)
            direction = true;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
