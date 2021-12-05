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
        this.m_beaverGauge.SetValue(humorManager.GetBeaversTauntValue());
        this.m_humanGauge.SetValue(humorManager.GetHumansTauntValue());

        this.ressources_manager.AddFood(rewardsFromTheDay["food"]);
        this.ressources_manager.AddWood(rewardsFromTheDay["wood"]);
        this.ressources_manager.AddSake(rewardsFromTheDay["sake"]);

        this.miniActionManager.UpdateMinis(queue.getQueueList());
        if (humorManager.GetBeaversTauntValue() >= 100f)
        {
            Debug.Log("ici");
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
