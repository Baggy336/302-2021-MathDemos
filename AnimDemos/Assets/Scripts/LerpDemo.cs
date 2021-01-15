using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    public GameObject objectStart;
    public GameObject objectEnd;
    [Range(0, 1)] public float percent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Lerpy();
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
}
