using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BezierQuadratic : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public Transform handle;

    public float percent = 0;

    public int curveRes = 10;

    [Header("Tween Stuff")]
    [Tooltip("How long the tween should take in seconds.")]
    [Range(.1f, 10)] public float tweenLength = 3;
    public AnimationCurve tweenSpeed;
    /// <summary>
    /// This value counts up when the animation is playing
    /// </summary>
    private float tweenTimer = 0;
    private bool isTweening = false;


    void Start()
    {
        
    }
    void Update()
    {
        if (isTweening)
        {
            tweenTimer += Time.deltaTime;
            float p = tweenTimer / tweenLength;

            // Evaluate a value for percent to pass into the curve
            percent = tweenSpeed.Evaluate(p);

            if (tweenTimer > tweenLength) isTweening = false;
        }

        transform.position = CalcPositionOnCurve(percent);
    }
    public void PlayTween()
    {
        tweenTimer = 0;
        isTweening = true;
    }
    private Vector3 CalcPositionOnCurve(float percent)
    {
        // posC = lerp between posA and handle
        Vector3 posC = AnimMath.Lerp(posA.position, handle.position, percent);
        // posD = lerp between handle and posB
        Vector3 posD = AnimMath.Lerp(handle.position, posB.position, percent);
        // posF = lerp between posC and posD
        Vector3 posF = AnimMath.Lerp(posC, posD, percent);

        return posF;
    }

    private void OnDrawGizmos()
    {
        Vector3 pos1 = posA.position;

        // Take percent and increase over time to get positions
        for (int i = 1; i < curveRes; i++)
        {
            // Turn one of the pieces into a float to avoid whole numbers
            float p = i / (float)curveRes;
            Vector3 pos2 = CalcPositionOnCurve(p);
            // Draw a line based on position
            Gizmos.DrawLine(pos1, pos2);
            pos1 = pos2;
        }
        Gizmos.DrawLine(pos1, posB.position);

    }
}


[CustomEditor(typeof(BezierQuadratic))]
public class BezierQuadraticEditor : Editor
{
    // Override the oninspector GUI
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //BezierCubic bezier = (BezierCubic)target; IF WANTED TO CAST A VARIABLE FIRST

        if (GUILayout.Button("Play Tween"))
        {
            (target as BezierQuadratic).PlayTween();
        }
    }
}