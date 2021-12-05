using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu]
public class Choice : ScriptableObject
{
    [Serializable]
    public struct results
    {
        public string type;
        public int value;
    }

    [Serializable]
    public struct need
    {
        public string type;
        public int value;
        public bool isChoosable;
    }
    public string nameChoice;
    public need[] needs;
    public results[] rewards;
    public results[] fail;
    public float probability;
    public bool isAttack;
    public int dayToFinish;
}