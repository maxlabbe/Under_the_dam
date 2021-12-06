using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ResourceDict : ScriptableObject
{
    [Serializable]
    public struct ResourceDictEntry
    {
        public string resourceType;
        public Sprite resourceSprite;
    }

    public ResourceDictEntry[] dict;
}
