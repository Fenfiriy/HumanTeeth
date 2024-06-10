using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 5.0f;
    float rotX;
    float rotY;

    // Start is called before the first frame update
    void Start()
    {
        rotX = -transform.rotation.eulerAngles.y;
        rotY = -transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the model with the middle mouse button held down
        if (Input.GetMouseButton(2))
        {
            // Rotate the model based on the mouse movement
            rotX += Input.GetAxis("Mouse X") * rotationSpeed;
            rotY += Input.GetAxis("Mouse Y") * rotationSpeed;
            rotY = Mathf.Clamp(rotY, -90, 90);

            transform.localRotation = Quaternion.Euler(-rotY, -rotX, 0);
        }
    }
}
