using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script creates a random object (cube,sphere,cylinder)
//with random size and color
//it also controls the global speed

public class spawnObject : MonoBehaviour
{
    //it is initialized to 1 in the Unity Interface
    public float movementSpeed;

    GameObject randomObject;
    // Start is called before the first frame update

    void Update()
    {
        //Control the global speed
        if (Input.GetKey(KeyCode.Greater)|| Input.GetKey(KeyCode.Period))
        {
             movementSpeed +=0.005f;
        }

        if ((Input.GetKey(KeyCode.Less)|| Input.GetKey(KeyCode.Comma)) && movementSpeed >0.005f)
        {
            movementSpeed -= 0.005f;
        }

        //generate objects
        if (Input.GetKeyDown(KeyCode.Space)){

            int objectId = UnityEngine.Random.Range(0, 3);

            Vector3 myScaling;
            int randomSize = UnityEngine.Random.Range(1, 11);

            if (objectId == 0){
                randomObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

                myScaling.x = randomSize;
                myScaling.y = randomSize;
                myScaling.z = randomSize;

            }
            else if (objectId == 1)
            {
                randomObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                myScaling.x = randomSize;
                myScaling.y = randomSize;
                myScaling.z = randomSize;

                //randomObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }
            else
            {
                randomObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                myScaling.x = randomSize;
                myScaling.y = randomSize/2f;
                myScaling.z = randomSize;
            }
            
            //the position that the object spawns is set to its size
            //to avoid collision with the cube in the begining
            Vector3 myPosition;

            myPosition.x = randomSize;
            myPosition.y = randomSize;
            myPosition.z = randomSize;
            
            //set a random color to the object
            byte r = (byte) UnityEngine.Random.Range(0, 256);
            byte g = (byte) UnityEngine.Random.Range(0, 256);
            byte b = (byte) UnityEngine.Random.Range(0, 256);

            randomObject.transform.position = myPosition;
            randomObject.transform.localScale = myScaling;
            randomObject.GetComponent<Renderer>().material.color = new Color32(r, g, b, 76);
            
            //we attach the script moveObject to the new object
            randomObject.AddComponent<moveObject>();
            randomObject.AddComponent<Rigidbody>().useGravity = false; //Disable Gravity
            randomObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous; //Set collision detection as continuous
            //attach a physic material to the new object           
            randomObject.GetComponent<Collider>().material = new PhysicMaterial("Bounce");
            
            //Set Spawner as the parent of the object to send it the movementSpeed 
            randomObject.transform.SetParent(transform, true);
        }
    }
}
