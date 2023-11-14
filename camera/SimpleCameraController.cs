using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour{
    public float speed = 10.0f;
    public float sensitivity = 5.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        Vector3 forwardDirection = Camera.main.transform.forward;
        Vector3 rightDirection = Camera.main.transform.right;

        forwardDirection.y = 0f;
        rightDirection.y = 0f;

        forwardDirection.Normalize();
        rightDirection.Normalize();

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += forwardDirection;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement -= rightDirection;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement -= forwardDirection;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += rightDirection;
        }

        movement.Normalize();

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * speed/1.1f * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * speed/1.1f * Time.deltaTime, Space.World);
        }

        // Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);
    }
}
