using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTowards : MonoBehaviour
{
    public Transform target;
    private Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        // Slides position towards the target
        transform.position = AnimMath.Slide(transform.position, cam.transform.position, .01f);

        // Get the vector to the target
        Vector3 vectorToTarget = target.position - transform.position;

        // Create the desired rotation
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        // Slide camera rotation to look at the target
        cam.transform.rotation = AnimMath.Slide(cam.transform.rotation, targetRotation, .05f);
    }
}
