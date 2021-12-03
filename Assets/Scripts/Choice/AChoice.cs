using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AChoice : MonoBehaviour
{

    public TextMeshProUGUI nameTextMesh;
    public TextMeshProUGUI numberTextMesh;
    public GameObject typeSprite;
    // public GameObject nonChoosableNeed;
    // public GameObject choosableNeed;

    public string nameChoice;

    public string typeName;
    public int currentNumber;
    public int numberMax;

    public void setChoice(string name, string type, int number_max)
    {
        nameChoice = name;
        typeName = type;
        numberMax = number_max;
        GameObject nameGameObject = gameObject.transform.Find("name").gameObject;
        nameTextMesh = nameGameObject.GetComponent<TextMeshProUGUI>();
        // GameObject numberGameObject = gameObject.transform.Find("number").gameObject;
        // numberTextMesh = numberGameObject.GetComponent<TextMeshProUGUI>();
        // typeSprite = gameObject.transform.Find("type_of_ressources").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nameTextMesh.SetText(nameChoice);
        switch (typeName)
        {
            case "Beaver":
                typeSprite.GetComponent<Image>().color = Color.blue;
                break;
            default:
                break;
        }
        numberTextMesh.SetText(currentNumber.ToString() + " / " + numberMax.ToString());
    }

    public void increment()
    {
        currentNumber = (currentNumber < numberMax) ? currentNumber + 1 : numberMax;
    }

    public void decrement()
    {
        currentNumber = (currentNumber > 0) ? currentNumber - 1 : 0;
    }
}
