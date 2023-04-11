using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script is used to rotate our camera in the sceen
public class moveCamera : MonoBehaviour
{
    
    private float x;
    private float y;
    
    //this variable holds the rotation vector
    private Vector3 rotateValue;

    public float movingSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        //get the position in X axis of the mouse
        x = Input.GetAxis("Mouse X") * movingSpeed;
        //get the position in X axis of the mouse
        y = Input.GetAxis("Mouse Y") * movingSpeed;

        //convertion of cartesian coordinates (X,Y) to polar coordinates
        rotateValue = new Vector3(y, -x, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
    }
}
