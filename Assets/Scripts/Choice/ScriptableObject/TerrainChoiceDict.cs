using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class TerrainChoiceDict : ScriptableObject{
    [Serializable]
    public struct TerrainChoiceEntry
    {
        public string terrainType;
        public  ChoicesPanelInfos choices;
    }

    public TerrainChoiceEntry[] dict;
}
