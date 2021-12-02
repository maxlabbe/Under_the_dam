using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Choices_Panel : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject prefab;
    public GameObject toggle;
    public GameObject choices_list;
    public ToggleGroup toggle_list;

    // Start is called before the first frame update
    void Start()
    {
        title.SetText("VOUS AVEZ LE CHOIX");
        description.SetText("Decidez de ce que vous allez faire");
        GameObject tmpChoice;
        GameObject tmpToggle;

        tmpChoice = Instantiate(prefab);
        tmpChoice.transform.parent = choices_list.transform;
        tmpChoice.GetComponent<AChoice>().setChoice("Attaque!", "Beaver", 10);
        tmpToggle = Instantiate(toggle);
        tmpToggle.transform.parent = toggle_list.transform;

        tmpChoice = Instantiate(prefab);
        tmpChoice.transform.parent = choices_list.transform;
        tmpChoice.GetComponent<AChoice>().setChoice("Récolte!", "Beaver", 5);
        tmpToggle = Instantiate(toggle);
        tmpToggle.transform.parent = toggle_list.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
