using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 1500f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the camera's forward direction
        Vector3 moveDirection = new Vector3 (vertical , 0f , horizontal).normalized;


        // Update the position of the GameObject in the direction the camera is facing
        transform.position += moveDirection;

        // Set the rotation to identity to prevent unwanted tilting
        transform.rotation = Quaternion.identity;
    }
}
