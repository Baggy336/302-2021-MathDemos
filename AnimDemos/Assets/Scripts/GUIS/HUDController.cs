using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    // Create our own timescale
    public static float timeScale = 1;
    
    public TMP_Text textTimescale;
    public Slider sliderLerp;
    public LerpDemo lerper;

    void Start()
    {
        SliderTimeUpdated(1);
    }

    void Update()
    {     
        float p = lerper.getCurrentPercent;

        sliderLerp.SetValueWithoutNotify(p);      
    }
    public void SliderTimeUpdated(float amt)
    {
        timeScale = amt;
        textTimescale.text = System.Math.Round(timeScale, 2).ToString();
    }
    public void SliderLerpUpdated(float amt)
    {
        lerper.Lerpy(amt);
    }
}
