using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is used for thr movement of the objects
//inside the cube and for applying the effect on the collisions

//every new object is child of Spawner (GameObject)

public class moveObject : MonoBehaviour
{
    GameObject inObject;
    
    Rigidbody rb;
    Vector3 last_velocity;

    ParticleSystem effect;
    GameObject copyEffect;
    
    //this speed is the constant speed that the object moves
    float speed;

    //user increases/decreases the global speed of the objects
    //this speed is inherited from parent(Spawner) 

    float movementSpeedInherited = 1f;

    void Start()
    {

        //the direction vector of the current object 
        //[10,90] of the world coordinate system -> [0.1,0.9] 

        float direction_on_x = UnityEngine.Random.Range(1,10)*10;
        float direction_on_y = UnityEngine.Random.Range(1,10)*10;
        float direction_on_z = UnityEngine.Random.Range(1,10)*10;

        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(direction_on_x, direction_on_y, direction_on_z);

        speed = rb.velocity.magnitude;

        //Find and copy the effect
        inObject = GameObject.Find("fireworksEffect");
        copyEffect = Instantiate(inObject);
        
        //set the effect to be a child of the current object
        copyEffect.transform.SetParent(transform, true);
        effect = copyEffect.GetComponent<ParticleSystem>();     
    }

    void FixedUpdate()
    {
        //get the global speed from parent's script (spawnObject) 
        movementSpeedInherited = transform.parent.GetComponent<spawnObject>().movementSpeed;
        rb.velocity = movementSpeedInherited * speed * (rb.velocity.normalized);
    }

    void OnCollisionEnter(Collision coll)
    {
        //get the name of the collider
        //and when there is a collision with the main cube or the main sphere
        //play the effects at the position of collision
        var objectname = coll.collider.gameObject.name;
        if (objectname == "front" || objectname == "back"|| objectname == "left"|| objectname == "right"|| objectname == "bottom"|| objectname == "top"|| objectname == "MainSphere")
        {
            transform.GetChild(0).GetComponent<ParticleSystem>().transform.position = coll.contacts[0].point;
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }   
    }
}
