using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBetween2Points : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public float percent;

    void LateUpdate()
    {
        transform.position = AnimMath.Lerp(pointA.position, pointB.position, percent);
    }
}
