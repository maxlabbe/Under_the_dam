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
    public ChoicesPanelInfos wood;
    public ChoicesPanelInfos big_wood;
    public ChoicesPanelInfos field;
    public ChoicesPanelInfos big_field;
    public ChoicesPanelInfos village;

    // Start is called before the first frame update
    void Start()
    {

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
        ChoicesPanelInfos tmp = ScriptableObject.CreateInstance<ChoicesPanelInfos>();
        switch (type)
        {
            case "wood":
                tmp = wood;
                break;
            case "big_wood":
                tmp = big_wood;
                break;
            case "field":
                tmp = field;
                break;
            case "big_field":
                tmp = big_field;
                break;
            case "village":
                tmp = village;
                break;
            default:
                tmp = wood;
                break;
        }
        title.SetText(tmp.title);
        description.SetText(tmp.description);
        foreach (Choice choice in tmp.choices)
        {
            GameObject tmpToogle = Instantiate(toggle);
            tmpToogle.GetComponent<Toggle>().group = this.toggle_list;
            tmpToogle.transform.SetParent(toggle_list.transform);
            GameObject tmpChoice = Instantiate(prefab);
            tmpChoice.transform.SetParent(choices_list.transform);
            tmpChoice.GetComponent<AChoice>().setChoice(choice);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void accept(){
        Toggle tmp = this.toggle_list.GetFirstActiveToggle();
        int index = tmp.transform.GetSiblingIndex();
        
        QueueAction queue = DayManager.instance.getQueue();
        AChoice resChoice = this.choices_list.transform.GetChild(index).gameObject.GetComponent<AChoice>();
        Action action = new Action(resChoice.choiceData, resChoice.actual_needs);
        queue.addActionToQueue(action);
        DayManager.instance.miniActionManager.UpdateMinis(queue.getQueueList());
        DayManager.instance.miniActionManager.Show();
        Debug.Log(this.choices_list.transform.GetChild(index).gameObject.GetComponent<AChoice>().nameTextMesh.text);
    }
}
