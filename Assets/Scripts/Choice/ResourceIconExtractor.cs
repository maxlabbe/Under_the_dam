using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceIconExtractor : MonoBehaviour
{
    public static ResourceIconExtractor instance { get; private set; }
    public ResourceDict resourceDict;
    private readonly Dictionary<string, Sprite> _extracted = new Dictionary<string, Sprite>();

    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        foreach (var entry in resourceDict.dict)
        {
            _extracted.Add(entry.resourceType,entry.resourceSprite);
        }
    }

    public Sprite Search(string resourceType)
    {
        return _extracted[resourceType];
    }
}
