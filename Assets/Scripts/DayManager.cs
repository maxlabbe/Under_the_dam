using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    private QueueAction queue;
    public int nDays;
    public TextMeshProUGUI daysCount;
    public TextMeshProUGUI actionsRewards;

    public HumorManager humorManager;

    public BeaverGauge m_beaverGauge;
    public HumanGauge m_humanGauge;

    public MiniActionManager miniActionManager;

    
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
            rewardsFromTheDay["Wood"], 
            rewardsFromTheDay["Food"], 
            rewardsFromTheDay["Sake"]);
        humorManager.AddBeaversTaunt(rewardsFromTheDay["Beaver_dis"]);
        humorManager.AddHumansTaunt(rewardsFromTheDay["Human_dis"]);

        m_beaverGauge.SetValue(humorManager.GetBeaversTauntValue());
        m_humanGauge.SetValue(humorManager.GetHumansTauntValue());

        miniActionManager.UpdateMinis(queue.getQueueList());
    }

    public QueueAction getQueue()
    {
        return this.queue;
    }

}
