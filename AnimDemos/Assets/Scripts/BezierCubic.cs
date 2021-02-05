using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BezierCubic : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public Transform handleA;
    public Transform handleB;

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
        // posC = lerp between posA and handleB
        Vector3 posC = AnimMath.Lerp(posA.position, handleA.position, percent);
        // posD = lerp between handleB and posB
        Vector3 posD = AnimMath.Lerp(handleB.position, posB.position, percent);
        // posE = lerp between the two handles
        Vector3 posE = AnimMath.Lerp(handleA.position, handleB.position, percent);
        // posF = lerp between posC and posD
        Vector3 posF = AnimMath.Lerp(posC, posE, percent);
        // posG = lerp between posE and posD
        Vector3 posG = AnimMath.Lerp(posE, posD, percent);    
        // Final output is lerp between posF and posG
        return AnimMath.Lerp(posF, posG, percent);
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


[CustomEditor(typeof(BezierCubic))]
public class BezierCubicEditor : Editor
{
    // Override the oninspector GUI
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //BezierCubic bezier = (BezierCubic)target; IF WANTED TO CAST A VARIABLE FIRST

        if (GUILayout.Button("Play Tween"))
        {
            (target as BezierCubic).PlayTween();
        }
    }
}