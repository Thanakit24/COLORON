using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
 
    public float offset;
 
    void Start()
    {   
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
 
    void LateUpdate()
    {
        //store camera's position in variable temp
        Vector3 temp = transform.position;
        //set the camera's position x to be equal to the player's x position 
        temp.x = playerTransform.position.x;
      
        
        
 
        //should add the offset value to the temporary camera x position
        temp.x += offset;
        
       
        
    
 
        //set back the camera's temp position to the camera's current position
        transform.position = temp;
    }
}
