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

    
    // Start is called before the first frame update
    void Start()
    {
        this.nDays = 0;
        this.queue = new QueueAction();
        this.humorManager = new HumorManager();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.queue.addActionToQueue(new Action());
            Debug.Log("Added action to queue");
            Debug.Log("Queue has "+ this.queue.getQueueList().Count+" actions");
        }
    }

    public void passDay()
    {
        this.nDays++;
        Dictionary<string, int> rewardsFromTheDay = this.queue.doAllActions();
        
        this.daysCount.SetText("Days : {0}", this.nDays);
        this.actionsRewards.SetText("R�compenses de la journ�e : \nBois : +{0}\nNourriture : +{1}\nSak� : +{2}",
            rewardsFromTheDay["Wood"], 
            rewardsFromTheDay["Food"], 
            rewardsFromTheDay["Sake"]);
        humorManager.AddBeaversTaunt(0.20f);
        humorManager.AddHumansTaunt(0.10f);

        BeaverGauge.instance.SetValue(humorManager.GetBeaversTauntValue());
        HumanGauge.instance.SetValue(humorManager.GetHumansTauntValue());
    }

    public QueueAction getQueue()
    {
        return this.queue;
    }

}
