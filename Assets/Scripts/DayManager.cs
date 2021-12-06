using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    public static DayManager instance{get; private set;}
    private QueueAction queue;
    public int nDays;
    public TextMeshProUGUI daysCount;
    public TextMeshProUGUI actionsRewards;

    public HumorManager humorManager;
    public RessourcesManager ressources_manager;


    public BeaverGauge m_beaverGauge;
    public HumanGauge m_humanGauge;

    public GameObject panelWin;

    public GameObject panelLost;

    public MiniActionManager miniActionManager;

    private void Awake(){
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        this.nDays = 0;
        this.queue = new QueueAction();
        this.humorManager = new HumorManager();
    }

    void Update()
    {}

    public void passDay()
    {
        this.nDays++;
        Dictionary<string, int> rewardsFromTheDay = this.queue.doAllActions();
        
        this.daysCount.SetText("Days : {0}", this.nDays);
        this.actionsRewards.SetText("Récompenses de la journée : \nBois : +{0}\nNourriture : +{1}\nSaké : +{2}",
            rewardsFromTheDay["wood"], 
            rewardsFromTheDay["food"], 
            rewardsFromTheDay["sake"]);
        this.humorManager.AddBeaversTaunt(rewardsFromTheDay["beaver_dis"]);
        this.humorManager.AddHumansTaunt(rewardsFromTheDay["human_dis"]);

        this.ressources_manager.AddFood(rewardsFromTheDay["food"]);
        this.ressources_manager.AddWood(rewardsFromTheDay["wood"]);
        this.ressources_manager.AddSake(rewardsFromTheDay["sake"]);

        this.miniActionManager.UpdateMinis(queue.getQueueList());

        this.ressources_manager.UseFood(ressources_manager.GetToothForce());
        this.ressources_manager.UseWood(ressources_manager.GetToothForce()/10);
        if(ressources_manager.GetFood() < 0) {
            humorManager.AddBeaversTaunt((Mathf.Abs(ressources_manager.GetFood())/ressources_manager.GetToothForce())*15);
            ressources_manager.SetFood(0);
        }
        if (ressources_manager.GetWood() < 0) {
            humorManager.AddBeaversTaunt((Mathf.Abs(ressources_manager.GetWood()*10)/ressources_manager.GetToothForce())*15);
            ressources_manager.SetWood(0);
        }

        this.m_beaverGauge.SetValue(humorManager.GetBeaversTauntValue());
        this.m_humanGauge.SetValue(humorManager.GetHumansTauntValue());

        if (humorManager.GetBeaversTauntValue() >= 100f)
        {
            this.panelLost.SetActive(true);
        }
        else if (humorManager.GetHumansTauntValue() >= 100f)
        {
            this.panelWin.SetActive(true);
        }
    }

    public QueueAction getQueue()
    {
        return this.queue;
    }

    public HumorManager getHumorManager()
    {
        return humorManager;
    }

}
