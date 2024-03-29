using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeaverGauge : MonoBehaviour
{
    public static BeaverGauge instance { get; private set; }
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
}
