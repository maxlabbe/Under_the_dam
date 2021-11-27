using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhareHouse_Manager : MonoBehaviour
{
    public RessourcesManager ressources_manager;
    public TextMeshProUGUI ressources_status;
    void Start()
    {
        /*this.ressources_status.SetText(
            "BOIS       : {0}\n" +
            "NOURRITURE : {1}\n" +
            "SAKE       : {2}\n",
            this.ressources_manager.GetWood(),
            this.ressources_manager.Getfood(),
            this.ressources_manager.GetSake()
         );*/
    }

    // Update is called once per frame
    void Update()
    {
        this.ressources_status.SetText(
            "BOIS       : {0}\n" +
            "NOURRITURE : {1}\n" +
            "SAKE       : {2}\n",
            this.ressources_manager.GetWood(),
            this.ressources_manager.Getfood(),
            this.ressources_manager.GetSake()
         );
    }
}
