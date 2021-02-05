using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    public GameObject objectStart;
    public GameObject objectEnd;
    
    [Range(-1, 2)] public float percent = 0;

    // Set length of animation
    public float animationLength = 2;
    private float animationPlayheadTime = 0;
    private bool isAnimPlaying = false;

    public AnimationCurve animationCurve;

    public float getCurrentPercent
    {
        get
        {
            return animationPlayheadTime / animationLength;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isAnimPlaying)
        {
            animationPlayheadTime += Time.deltaTime;

            // Calculate a new val for percent
            percent = getCurrentPercent;
            // Clamp the range from 0 to 1
            percent = Mathf.Clamp(percent, 0, 1);

            //percent = percent * percent; // Ease in: speed up
            //percent = percent * percent * (3 - 2 * percent); // Smooth step: speeds up, then slows down.

            float p = animationCurve.Evaluate(percent);

            // Move object to lerped position
            Lerpy(p);
            // Stop playing
            if (percent >= 1) isAnimPlaying = false;
        }
        
    }

    public void Lerpy(float p)
    {
        transform.position = AnimMath.Lerp(
                    objectStart.transform.position,
                    objectEnd.transform.position,
                    p
                    );
    }

    private void OnValidate()
    {
        Lerpy(percent);
    }

    public void PlayTweenAnim()
    {
        isAnimPlaying = true;
        animationPlayheadTime = 0;
    }
}
