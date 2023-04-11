using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script gets the faces of the cube (up,bottom,left,right,front,back) 
//through drag and drop from the Unity interface and sets a random color to them


public class createRandomColor : MonoBehaviour
{
	//The material we want to change color
    Material ourmaterial;

    // Start is called before the first frame update
    void Start()
    {   
        //Getting random color (RGB) 
        byte r = (byte) UnityEngine.Random.Range(0, 256);
        byte g = (byte) UnityEngine.Random.Range(0, 256);
        byte b = (byte) UnityEngine.Random.Range(0, 256);
        Color ourcolor=new Color32(r, g, b, 76);
        ourmaterial = Resources.Load("quadColor", typeof(Material)) as Material; //path is "Assets/Resources/quadColor.mat"
        ourmaterial.color=ourcolor;
    }
}
