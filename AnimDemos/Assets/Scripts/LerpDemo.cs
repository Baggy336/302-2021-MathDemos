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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimPlaying)
        {
            animationPlayheadTime += Time.deltaTime;

            // Calculate a new val for percent
            percent = animationPlayheadTime / animationLength;
            // Clamp the range from 0 to 1
            percent = Mathf.Clamp(percent, 0, 1);
            // Move object to lerped position
            Lerpy();
            // Stop playing
            if (percent >= 1) isAnimPlaying = false;
        }
        
    }

    private void Lerpy()
    {
        transform.position = AnimMath.Lerp(
                    objectStart.transform.position,
                    objectEnd.transform.position,
                    percent
                    );
    }

    private void OnValidate()
    {
        Lerpy();
    }

    public void PlayTweenAnim()
    {
        isAnimPlaying = true;
        animationPlayheadTime = 0;
    }
}
