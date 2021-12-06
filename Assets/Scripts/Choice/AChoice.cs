using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AChoice : MonoBehaviour
{
    public Choice choiceData;
    public TextMeshProUGUI nameTextMesh;
    public GameObject prefabChoosableNeed;
    public GameObject prefabNonChoosableNeed;
    public GameObject needsList;
    public Dictionary<string, int> max_needs;
    public Dictionary<string, int> actual_needs;

    // public GameObject nonChoosableNeed;
    // public GameObject choosableNeed;

    public void setChoice(Choice choice)
    {
        choiceData = choice;
        max_needs = new Dictionary<string, int>();
        actual_needs = new Dictionary<string, int>();
        GameObject nameGameObject = gameObject.transform.Find("name").gameObject;
        nameTextMesh = nameGameObject.GetComponent<TextMeshProUGUI>();
        nameTextMesh.SetText(choice.nameChoice);
        foreach (Choice.need need in choice.needs)
        {
            max_needs.Add(need.type, need.value);
            actual_needs.Add(need.type, 0);
            if (need.isChoosable)
            {
                GameObject tmpChoosableNeed = Instantiate(prefabChoosableNeed);
                tmpChoosableNeed.transform.SetParent(needsList.transform);
                Button downbutton = tmpChoosableNeed.transform.Find("arrowAndType").Find("down").gameObject.GetComponent<Button>();
                Button upbutton = tmpChoosableNeed.transform.Find("arrowAndType").Find("up").gameObject.GetComponent<Button>();
                downbutton.onClick.AddListener(delegate { decrement(need.type); });
                upbutton.onClick.AddListener(delegate { increment(need.type); });
                Image typeImage = tmpChoosableNeed.transform.Find("arrowAndType").Find("type_of_ressources").gameObject.GetComponent<Image>();
                typeImage.overrideSprite = ResourceIconExtractor.instance.Search(need.type);
                TextMeshProUGUI number = tmpChoosableNeed.transform.Find("number").gameObject.GetComponent<TextMeshProUGUI>();
                number.SetText(actual_needs[need.type].ToString() + " / " + max_needs[need.type].ToString());
                if (need.value == 0)
                {
                    tmpChoosableNeed.SetActive(false);
                }
            }
            else
            {
                GameObject tmpNonChoosableNeed = Instantiate(prefabNonChoosableNeed);
                tmpNonChoosableNeed.transform.SetParent(needsList.transform);
                Image typeImage = tmpNonChoosableNeed.transform.Find("arrowAndType").Find("type_of_ressources").gameObject.GetComponent<Image>();
                typeImage.overrideSprite = ResourceIconExtractor.instance.Search(need.type);
                TextMeshProUGUI number = tmpNonChoosableNeed.transform.Find("number").gameObject.GetComponent<TextMeshProUGUI>();
                switch (need.type)
                {
                    case "wood":
                        actual_needs[need.type] = Mathf.Min(RessourcesManager.instance.GetWood(), max_needs[need.type]);
                        break;
                    case "food":
                        actual_needs[need.type] = Mathf.Min(RessourcesManager.instance.GetFood(), max_needs[need.type]);
                        break;
                    case "beaver":
                        actual_needs[need.type] = Mathf.Min(RessourcesManager.instance.m_toothForce.getFreeBeaversNumber(), max_needs[need.type]);
                        break;
                    case "sake":
                        actual_needs[need.type] = Mathf.Min(RessourcesManager.instance.GetSake(), max_needs[need.type]);
                        break;
                    default:
                        break;
                }
                number.SetText(actual_needs[need.type].ToString() + " / " + max_needs[need.type].ToString());
                if (need.value == 0)
                {
                    tmpNonChoosableNeed.SetActive(false);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void increment(string type)
    {
        int minimumNeed;
        switch (type)
        {
            case "wood":
                minimumNeed = Mathf.Min(max_needs[type], RessourcesManager.instance.GetWood());
                actual_needs[type] = (actual_needs[type] < minimumNeed) ? actual_needs[type] + 1 : minimumNeed;
                break;
            case "food":
                minimumNeed = Mathf.Min(max_needs[type], RessourcesManager.instance.GetFood());
                actual_needs[type] = (actual_needs[type] < minimumNeed) ? actual_needs[type] + 1 : minimumNeed;
                break;
            case "beaver":
                minimumNeed = Mathf.Min(max_needs[type], RessourcesManager.instance.m_toothForce.getFreeBeaversNumber());
                actual_needs[type] = (actual_needs[type] < minimumNeed) ? actual_needs[type] + 1 : minimumNeed;
                break;
            case "sake":
                minimumNeed = Mathf.Min(max_needs[type], RessourcesManager.instance.GetSake());
                actual_needs[type] = (actual_needs[type] < minimumNeed) ? actual_needs[type] + 1 : minimumNeed;
                break;
            default:
                break;
        }


        int i = 0;
        foreach (var item in actual_needs.Keys)
        {
            if (item == type)
            {
                break;
            }
            i++;
        }
        needsList.transform.GetChild(i).Find("number").gameObject.GetComponent<TextMeshProUGUI>().SetText(actual_needs[type].ToString() + " / " + max_needs[type].ToString());
    }

    public void decrement(string type)
    {
        actual_needs[type] = (actual_needs[type] > 0) ? actual_needs[type] - 1 : 0;
        int i = 0;
        foreach (var item in actual_needs.Keys)
        {
            if (item == type)
            {
                break;
            }
            i++;
        }
        needsList.transform.GetChild(i).Find("number").gameObject.GetComponent<TextMeshProUGUI>().SetText(actual_needs[type].ToString() + " / " + max_needs[type].ToString());
    }
}
