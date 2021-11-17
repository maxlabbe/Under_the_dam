using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    private QueueAction queue;
    public int nDays;
    public TextMeshProUGUI textmeshPro;

    // Start is called before the first frame update
    void Start()
    {
        this.nDays = 0;
        this.queue = new QueueAction();
        TextMeshProUGUI textmeshPro = this.GetComponentInChildren<TextMeshProUGUI>();
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
        Dictionary<string, int> rewardsFromTheDay = queue.doAllActions();
        
        textmeshPro.SetText("Days : {0}", this.nDays);

    }

}
