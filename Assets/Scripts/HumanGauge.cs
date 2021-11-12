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
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }

    private void Update()
    {
        testPercentage += 0.001f;
        if (testPercentage>1)
        {
            testPercentage = 0;
        }
        //For testing
        HumanGauge.instance.SetValue(testPercentage);
    }
}
