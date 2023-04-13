using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    void Start()
    {
        //Debug.Log("Test");
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void YMovement(float speed)
    {
        transform.position += new Vector3(0, speed, 0);
        if (speed > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    public void XMovement(float speed)
    {
        transform.position += new Vector3(speed, 0, 0);
        if (speed > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

}
