using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragObstacle : MonoBehaviour
{

    private int speed = 7;
    private float movX = 0.9f;
    private float movnX = -0.9f;
    private bool direction = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void move()
    {
        if (direction)
        {
            transform.position += new Vector3(movnX * speed * Time.deltaTime, 0.0f, 0.0f);

        }

        if (transform.position.x < -7.2f)
            direction = false;
        if (!direction)
            transform.position += new Vector3(movX * speed * Time.deltaTime, 0.0f, 0.0f);
        if (transform.position.x > 7.2f)
            direction = true;

    }

    // Update is called once per frame
    void Update()
    {
        //print("hello");
        move();
    }
}
