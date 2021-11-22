using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Choices : MonoBehaviour
{
    Dictionary<string, ChoiceInfos> choices;
    public Choices(string path)
    {
        string json = File.ReadAllText(Application.dataPath + path);
        Choices data = JsonUtility.FromJson<Choices>(json);

    }
    public void Start() {
        string json = File.ReadAllText(Application.dataPath + "/data/event.json");
        Choices data = JsonUtility.FromJson<Choices>(json);

    }
}
