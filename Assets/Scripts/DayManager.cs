using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    private QueueAction queue;
    public int nDays;

    // Start is called before the first frame update
    void Start()
    {
        this.nDays = 0;
        this.queue = new QueueAction();

    }

    public void passDay()
    {
        this.nDays++;
        Dictionary<string, int> rewardsFromTheDay = queue.doAllActions();
        Debug.Log(nDays);
    }

}
