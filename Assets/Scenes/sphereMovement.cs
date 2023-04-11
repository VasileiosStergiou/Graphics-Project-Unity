using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereMovement : MonoBehaviour
{
    private Transform target;

    public Material initialColor;
    public Material texture;

    int check_bottom = 0;
    int check_top = 0;
    int check_left = 0;
    int check_right = 0;
    int check_front = 0;
    int check_back = 0;

    Vector3 myPosition;

    public float speed;

    int textureOn = 1;

    void Start()
    {
        myPosition = transform.position;
        GetComponent<Renderer>().material = initialColor;
    }


    void Update()
    {
        //Enable and disable texture
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (textureOn == 0)
            {
                GetComponent<Renderer>().material = initialColor;
                textureOn = 1;
            }
            else
            {
                GetComponent<Renderer>().material = texture;
                textureOn = 0;
            }

        }
        //Sphere moment
        if (Input.GetKey(KeyCode.UpArrow) && check_top == 0)
        {
            myPosition.y += speed * Time.deltaTime;
            transform.position = myPosition;
        }

        if (Input.GetKey(KeyCode.DownArrow) && check_bottom == 0)
        {
            myPosition.y -= speed * Time.deltaTime;
            transform.position = myPosition;
        }


        if (Input.GetKey(KeyCode.RightArrow) && check_right == 0)
        {
            myPosition.x += speed * Time.deltaTime;
            transform.position = myPosition;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && check_left == 0)
        {

            myPosition.x -= speed * Time.deltaTime;
            transform.position = myPosition;
        }

        if ((Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.Underscore) || Input.GetKey(KeyCode.KeypadMinus)) && check_front == 0)
        {
            myPosition.z -= speed * Time.deltaTime;
            transform.position = myPosition;
        }

        if ((Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.Equals) || Input.GetKey(KeyCode.KeypadPlus)) && check_back == 0)
        {
            myPosition.z += speed * Time.deltaTime;
            transform.position = myPosition;
        }


    }

    void OnCollisionStay(Collision sth)
    {
        //if there is a collision with cube
        //disable its movement on that specific direction
        var objectname = sth.collider.gameObject.name;
        if (objectname == "front")
        {
            check_front = 1;
        }
        if (objectname == "back")
        {
            check_back = 1;
        }
        if (objectname == "left")
        {
            check_left = 1;
        }
        if (objectname == "right")
        {
            check_right = 1;
        }
        if (objectname == "bottom")
        {
            check_bottom = 1;
        }
        if (objectname == "top")
        {
            check_top = 1;
        }
    }

    void OnCollisionExit(Collision sth)
    {
        //If there is no collision with the cube
        //enable movement of the main sphere

        var objectname = sth.collider.gameObject.name;
        if (objectname == "front")
        {
            check_front = 0;
        }
        if (objectname == "back")
        {
            check_back = 0;
        }
        if (objectname == "left")
        {
            check_left = 0;
        }
        if (objectname == "right")
        {
            check_right = 0;
        }
        if (objectname == "bottom")
        {
            check_bottom = 0;
        }
        if (objectname == "top")
        {
            check_top = 0;
        }
    }
}
