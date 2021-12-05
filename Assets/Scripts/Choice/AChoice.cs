using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AChoice : MonoBehaviour
{

    public TextMeshProUGUI nameTextMesh;
    public GameObject prefabChoosableNeed;
    public GameObject prefabNonChoosableNeed;
    public GameObject needsList;
    public int[] max_needs;
    public int[] actual_needs;
    public Sprite wood_Sprite;
    public Sprite food_Sprite;
    public Sprite sake_Sprite;
    public Sprite beaver_Sprite;
    public int nonUsedNeed;

    // public GameObject nonChoosableNeed;
    // public GameObject choosableNeed;

    public void setChoice(Choice choice)
    {
        max_needs = new int[4];
        actual_needs = new int[4];
        GameObject nameGameObject = gameObject.transform.Find("name").gameObject;
        nameTextMesh = nameGameObject.GetComponent<TextMeshProUGUI>();
        nameTextMesh.SetText(choice.nameChoice);
        nonUsedNeed = 0;
        int i = 0;
        foreach (Choice.need need in choice.needs)
        {
            max_needs[i] = need.value;
            actual_needs[i] = 0;
            if (need.value != 0)
            {
                if (need.isChoosable)
                {
                    GameObject tmpChoosableNeed = Instantiate(prefabChoosableNeed);
                    tmpChoosableNeed.transform.SetParent(needsList.transform);
                    Button downbutton = tmpChoosableNeed.transform.Find("arrowAndType").Find("down").gameObject.GetComponent<Button>();
                    Button upbutton = tmpChoosableNeed.transform.Find("arrowAndType").Find("up").gameObject.GetComponent<Button>();
                    int i2 = i;
                    downbutton.onClick.AddListener(delegate { decrement(i2); });
                    upbutton.onClick.AddListener(delegate { increment(i2); });
                    Image typeImage = tmpChoosableNeed.transform.Find("arrowAndType").Find("type_of_ressources").gameObject.GetComponent<Image>();
                    switch (need.type)
                    {
                        case "wood":
                            typeImage.sprite = wood_Sprite;
                            break;
                        case "food":
                            typeImage.sprite = food_Sprite;
                            break;
                        case "sake":
                            typeImage.sprite = sake_Sprite;
                            break;
                        case "beaver":
                            typeImage.sprite = beaver_Sprite;
                            break;
                        default:
                            break;
                    }
                    TextMeshProUGUI number = tmpChoosableNeed.transform.Find("number").gameObject.GetComponent<TextMeshProUGUI>();
                    number.SetText(actual_needs[i].ToString() + " / " + max_needs[i].ToString());
                }
                else
                {
                    GameObject tmpNonChoosableNeed = Instantiate(prefabNonChoosableNeed);
                    tmpNonChoosableNeed.transform.SetParent(needsList.transform);
                    Image typeImage = tmpNonChoosableNeed.transform.Find("arrowAndType").Find("type_of_ressources").gameObject.GetComponent<Image>();
                    switch (need.type)
                    {
                        case "wood":
                            typeImage.sprite = wood_Sprite;
                            break;
                        case "food":
                            typeImage.sprite = food_Sprite;
                            break;
                        case "sake":
                            typeImage.sprite = sake_Sprite;
                            break;
                        case "beaver":
                            typeImage.sprite = beaver_Sprite;
                            break;
                        default:
                            break;
                    }
                    TextMeshProUGUI number = tmpNonChoosableNeed.transform.Find("number").gameObject.GetComponent<TextMeshProUGUI>();
                    number.SetText(actual_needs[i].ToString() + " / " + max_needs[i].ToString());
                }
            }
            else
            {
                nonUsedNeed++;
            }
            i++;
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

    public void increment(int i)
    {
        actual_needs[i] = (actual_needs[i] < max_needs[i]) ? actual_needs[i] + 1 : max_needs[i];
        needsList.transform.GetChild(i - nonUsedNeed).Find("number").gameObject.GetComponent<TextMeshProUGUI>().SetText(actual_needs[i].ToString() + " / " + max_needs[i].ToString());
    }

    public void decrement(int i)
    {
        actual_needs[i] = (actual_needs[i] > 0) ? actual_needs[i] - 1 : 0;
        needsList.transform.GetChild(i - nonUsedNeed).Find("number").gameObject.GetComponent<TextMeshProUGUI>().SetText(actual_needs[i].ToString() + " / " + max_needs[i].ToString());
    }
}
