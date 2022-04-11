using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChoiceExtractor : MonoBehaviour
{
    public static TerrainChoiceExtractor instance { get; private set; }
    public  TerrainChoiceDict terrainChoiceDict;
    private readonly Dictionary<string, ChoicesPanelInfos> ExtractedTerrainChoiceDict= new Dictionary<string, ChoicesPanelInfos>();

    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        foreach(var entry in terrainChoiceDict.dict)
        {
            ExtractedTerrainChoiceDict.Add(entry.terrainType,entry.choices);
        }
    }

    public ChoicesPanelInfos Search(string terrainType)
    {
        return ExtractedTerrainChoiceDict[terrainType];
    }
    
    
    
}
