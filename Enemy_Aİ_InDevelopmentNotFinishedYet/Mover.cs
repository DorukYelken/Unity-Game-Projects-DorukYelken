using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float speed = 40f;
    float speedMouse = 2.0f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMouseInput();
    }

    void FixedUpdate()
    {
        HandleMovementInput(speed);
    }

    void HandleMouseInput()
    {
        // Get the mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the entire GameObject (including the camera) based on mouse movement
        transform.Rotate(Vector3.up * mouseX * speedMouse);

        // Rotate the camera
        Camera.main.transform.Rotate(Vector3.left * mouseY * speedMouse);
        Camera.main.transform.Rotate(Vector3.up * mouseX * speedMouse);
        Vector3 currentRotation = Camera.main.transform.rotation.eulerAngles;
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0f);
    }

    void HandleMovementInput(float speed)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the camera's forward direction
        Vector3 moveDirection = (Camera.main.transform.forward * vertical + Camera.main.transform.right * horizontal).normalized;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed += 80f;
        }
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);

        // Set the rotation to identity to prevent unwanted tilting
        transform.rotation = Quaternion.identity;

    }
}


