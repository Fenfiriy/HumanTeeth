using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 5.0f;
    [SerializeField]
    float speed = 5.0f;
    float rotX;
    float rotY;

    // Start is called before the first frame update
    void Start()
    {
        rotX = transform.rotation.eulerAngles.y;
        rotY = -transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the camera with the right mouse button held down
        if (Input.GetMouseButton(1))
        {
            // Rotate the camera based on the mouse movement
            rotX += Input.GetAxis("Mouse X") * rotationSpeed;
            rotY += Input.GetAxis("Mouse Y") * rotationSpeed;
            rotY = Mathf.Clamp(rotY, -90, 90);

            transform.localRotation = Quaternion.Euler(-rotY, rotX, 0);

            // Move the camera based on the keyboard input
            float axisRight = Input.GetAxis("Right");
            float axisForward = Input.GetAxis("Forward");
            float axisUp = Input.GetAxis("Up");

            transform.position += transform.forward * axisForward * speed + transform.right * axisRight * speed + transform.up * axisUp * speed;
        }
    }
}
