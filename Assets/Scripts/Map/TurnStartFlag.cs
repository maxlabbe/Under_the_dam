using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStartFlag : MonoBehaviour
{
    public static TurnStartFlag instance { get; private set; }
    public bool flag = true;

    private void Awake()
    {
        instance = this;
    }

    public void SetFlag(bool state)
    {
        flag = state;
    }
}
