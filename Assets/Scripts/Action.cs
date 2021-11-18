using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action{

    private int daysToFinish;
    private bool inProg;
    private Dictionary<string, int> rewards;

    public Action() 
    {
        this.rewards = new Dictionary<string, int>();
        this.daysToFinish = 3;
        this.inProg = true;
        this.rewards.Add("Wood", 10);
        this.rewards.Add("Food", 10);
        this.rewards.Add("Beaver", 0);
        this.rewards.Add("Sake", 1);
    }

    public bool doSelf()
    {
        this.daysToFinish--;
        if(this.daysToFinish <= 0)
        {
            this.inProg = false;
        }
        return !this.inProg;
    }
    

    public Dictionary<string, int> finishAction()
    {
        Debug.Log("Action done");
        return this.rewards;
    }

    public int getDaysToFinish()
    {
        return this.daysToFinish;
    }
}
