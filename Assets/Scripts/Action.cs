using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action{

    public int daysToFinish;
    private bool inProg;
    private Dictionary<string, int> rewards;
    public int n_beavers;

    public Action() 
    {
        this.rewards = new Dictionary<string, int>();
        this.daysToFinish = 3;
        this.inProg = true;
        this.rewards.Add("Wood", 10);
        this.rewards.Add("Food", 10);
        this.rewards.Add("Beaver", 0);
        this.rewards.Add("Sake", 1);
        this.rewards.Add("Beaver_dis", 10);
        this.rewards.Add("Human_dis", 10);
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

    public Dictionary<string,int> getRewardsDict()
    {
        return this.rewards;
    }

    public int getNBeavers()
    {
        return this.n_beavers;
    }

    public void initRewardDict()
    {
        this.rewards.Add("Wood", 0);
        this.rewards.Add("Food", 0);
        this.rewards.Add("Beaver", 0);
        this.rewards.Add("Sake", 0);
        this.rewards.Add("Beaver_dis", 0);
        this.rewards.Add("Human_dis", 0);
    }

    public void setRewardsDict(int n_wood, int n_food, int n_beaver, int n_sake, int n_beaver_dis, int n_human_dis)
    {
        this.rewards["Wood"] = n_wood;
        this.rewards["Food"] = n_food;
        this.rewards["Beaver"] = n_beaver;
        this.rewards["Sake"] = n_sake;
        this.rewards["Beaver_dis"] = n_beaver_dis;
        this.rewards["Human_dis"] = n_human_dis;
    }
}
