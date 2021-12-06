using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhareHouse_Manager : MonoBehaviour
{
    public RessourcesManager ressources_manager;
    public TextMeshProUGUI[] ressources_status;

    // Update is called once per frame
    public void UpdateWarehousNumbers()
    {
        ressources_status[0].SetText(ressources_manager.GetWood().ToString());
        ressources_status[1].SetText(ressources_manager.GetFood().ToString());
        ressources_status[2].SetText(ressources_manager.m_toothForce.getFreeBeaversNumber() + " / " + ressources_manager.GetToothForce().ToString());
        ressources_status[3].SetText(ressources_manager.GetSake().ToString());
    }
}
