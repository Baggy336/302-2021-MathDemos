using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GenerateRingPath : MonoBehaviour
{
    [Range(10, 60)] public int num = 10;
    [Range(3, 20)] public float radius = 5;
    LineRenderer line;

    void Start()
    {
        GeneratePath();
    }
    void OnValidate()
    {
        GeneratePath();
    }

    private void GeneratePath()
    {
        line = GetComponent<LineRenderer>();

        // Generate points

        float rad = 0;

        Vector3[] pts = new Vector3[num];

        for (int i = 0; i < num; i++)
        {
            pts[i] = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius; // Outputs a 1 meter long direction
            rad += Mathf.PI * 2 / num; // Increase the angle based on num.
        }
        line.positionCount = num;
        line.SetPositions(pts);
    }
}
