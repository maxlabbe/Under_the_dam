using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json.Linq;
using TMPro;

public class Choices_Panel : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject prefab;
    public GameObject toggle;
    public GameObject choices_list;
    public ToggleGroup toggle_list;
    private dynamic data;

    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/data/action.json");
        data = JObject.Parse(json);
    }

    public void setAllChoices(string type) {
        foreach (Transform child in this.toggle_list.transform)
        {
            GameObject.Destroy(child.gameObject);
            GameObject.Destroy(child);
        }
        foreach (Transform child in this.choices_list.transform)
        {
            GameObject.Destroy(child.gameObject);
            GameObject.Destroy(child);
        }
        string json = File.ReadAllText(Application.dataPath + "/data/action.json");
        data = JObject.Parse(json);
        dynamic typedata = data.wood;
        switch (type)
        {
            case "wood":
                typedata = data.wood;
                break;
            case "big_wood":
                typedata = data.big_wood;
                break;
            case "field":
                typedata = data.field;
                break;
            case "big_field":
                typedata = data.big_field;
                break;
            case "village":
                typedata = data.village;
                break;
            default:
                break;
        }

        title.SetText((string)typedata.title);
        description.SetText((string)typedata.description);
        GameObject tmpChoice;
        GameObject tmpToggle;

        foreach (dynamic item in typedata.choices)
        {
            tmpChoice = Instantiate(prefab);
            tmpChoice.transform.SetParent(choices_list.transform);
            tmpChoice.GetComponent<AChoice>().setChoice((string)item.name, ((string)item.needs).Split(':')[0], (int)int.Parse(((string)item.needs).Split(':')[1]));

            tmpToggle = Instantiate(toggle);
            tmpToggle.transform.SetParent(toggle_list.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
