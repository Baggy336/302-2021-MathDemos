using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCameraControl : MonoBehaviour
{
    // Tilt of the camera in degrees
    float pitch = 0;
    float targetPitch = 0;
    // The yaw angle of the rig in degrees
    float yaw = 0;
    float targetYaw = 0;
    // How far away the camera is from the target in m
    float dollyDis = 10;
    float targetDollyDis = 10;
    public float mouseSensitivityY = 1; // Vertical mouse input
    public float mouseSensitivityX = 1; // Horizontal mouse input

    public float mouseScrollMultiplier = 5;
    
    private Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        // Use right click to drag the camera
        if (Input.GetButton("Fire2"))
        {
            // Change the pitch
            float mouseY = Input.GetAxis("Mouse Y");
            float mouseX = Input.GetAxis("Mouse X");
            targetPitch += mouseY * mouseSensitivityY; // Move the target to mouse
            targetYaw += mouseX * mouseSensitivityX;
        }

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        targetDollyDis += scroll * mouseScrollMultiplier;
        targetDollyDis = Mathf.Clamp(targetDollyDis, 2.5f, 15);
        
        dollyDis = AnimMath.Slide(dollyDis, targetDollyDis, .05f);
        cam.transform.localPosition = new Vector3(0, 0, -dollyDis);

        // Clamp the pitch degrees


        //Quaternion targetRotation = Quaternion.Euler(pitch, yaw, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.01f);

        targetPitch = Mathf.Clamp(targetPitch, -89, 89);

        pitch = AnimMath.Slide(pitch, targetPitch, .05f); // Ease from current to target
        yaw = AnimMath.Slide(yaw, targetYaw, .05f);
     
        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}
