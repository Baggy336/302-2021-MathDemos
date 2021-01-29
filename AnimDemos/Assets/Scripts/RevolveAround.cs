using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveAround : MonoBehaviour
{

    public Transform target;

    public float radius = 2;
    private float age = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime * HUDController.timeScale; // Use timescale with delta time

        Vector3 offset = AnimMath.SpotOnCircleXZ(radius, age);
        // math
        transform.position = target.position + offset;

    }
}

