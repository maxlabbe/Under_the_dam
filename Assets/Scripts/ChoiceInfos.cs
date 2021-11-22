using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ChoiceInfos
{
    public string cost;
    public string rewards;

    public ChoiceInfos(string path) {
        string dataJson = File.ReadAllText(Application.dataPath + path);
        
    }

}