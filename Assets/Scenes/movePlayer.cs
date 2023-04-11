using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script moves the player
//in the orienation of the camera

public class movePlayer : MonoBehaviour
{
    Camera playerCamera;

    //the user sets the speed from the Unity Interface
    //it is initilized to 300

    public float speed;

    void Start()
    {
        //Get the camera which is a child of OurPlayer
        playerCamera = transform.GetChild(0).GetComponent<Camera>();
        //Hide the cursor
        Cursor.visible = false;
        //locks the cursor inside the window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {   
        //When escape is pressed, the cursor appeares again and
        //is unlocked
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //Player movement

        if (Input.GetKey(KeyCode.W))
        {
            //move Forward
            transform.localPosition += playerCamera.transform.forward * speed * Time.deltaTime;  
        }

        if (Input.GetKey(KeyCode.S))
        {
            //move Back
            transform.localPosition -= playerCamera.transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //move Right
            transform.localPosition += playerCamera.transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //move Left
            transform.localPosition -= playerCamera.transform.right * speed * Time.deltaTime;
        }
    }
}
