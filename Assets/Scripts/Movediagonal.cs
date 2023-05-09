using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movediagonal : MonoBehaviour
{

    private bool direction = true;
    private int speed = 7;
    private float mov = 0.9f;
    private float movn = -0.9f;
    void move()
    {
        if (direction)
            transform.localPosition += new Vector3(0.0f, 0.0f, mov * speed * Time.deltaTime);
        if (transform.localPosition.z > 0.8f) // 2.8f
            direction = false;
        if (!direction)
        {
            transform.localPosition += new Vector3(0.0f, 0.0f, movn * speed * Time.deltaTime);
        }
        if (transform.localPosition.z < -1.8f) // -1.2f
            direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    //    if (direction)
    //            transform.localPosition += new Vector3(0.0f, mov* speed * Time.deltaTime, mov* speed * Time.deltaTime);
    //        if (transform.localPosition.y > 3.0f && transform.localPosition.z > 3.0f)
    //            direction = false;
    //        if (!direction)
    //        {
    //            transform.position += new Vector3(0.0f, movn* speed * Time.deltaTime, movn* speed * Time.deltaTime);
    //}
    //if (transform.position.y < -0.1f && transform.position.z < -0.1f)
    //    direction = true;

}
