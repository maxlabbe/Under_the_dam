using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HumanGauge : MonoBehaviour
{
    public static HumanGauge instance { get; private set; }
    public Image mask;
    float originalSize;
    private float testPercentage=0;

    public HumorManager humor;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        SetValue(0);
    }

    public void SetValue(float value)
    {				      
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value/100);
    }

    private void Update()
    {
        //float tauntValue = humor.GetHumansTauntValue();
        //HumanGauge.instance.SetValue(tauntValue);
        //For testing
        /*
        testPercentage += 0.001f;
        if (testPercentage>1)
        {
            testPercentage = 0;
        }       
        HumanGauge.instance.SetValue(testPercentage);*/
    }
}
