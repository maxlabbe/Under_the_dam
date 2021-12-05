using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Action
{

    public int daysToFinish;
    private int m_timeToDo;
    private bool inProg;
    private int m_wood;
    private int m_food;
    private string m_type;
    public int n_beavers;
    private int successChance;
    private Dictionary<string, int> rewards;
    private Dictionary<string, int> failureRewards;
    private int n_sake;

    //TODO - Edit: configurable daysToFinish,     (=>OK)
    //TODO - Implement: Rewards when the action fails,       (=>OK)
    //TODO - Implement: determine success/failure when resolving the action,      (=>REVIEW)
    //TODO - Implement: sake amount can affect [reward amount],[time to resolve (?)] etc.    
    //TODO - Implement: number of beaver assigned can affect [success chance], [time to resolve (?)], etc. (=> REVIEW)
    
    public Action(int wood, int food, int beaver,int sake,int timeToFinish, int successChance, string type)
    {
        
        this.m_wood = wood;
        this.m_food = food;
        this.n_beavers = beaver;
        this.n_sake = sake;
        this.m_type = type;
        this.successChance = successChance;
        this.rewards = new Dictionary<string, int>();
        this.daysToFinish = timeToFinish;
        this.m_timeToDo = this.daysToFinish;
        this.inProg = true;
        initRewardDict();
        failureRewards = new Dictionary<string, int>(rewards);
    }

    public bool doSelf()
    {
        this.daysToFinish--;
        if (this.daysToFinish > 0) return !this.inProg;
        
        this.inProg = false;
        return !this.inProg;
    }


    public Dictionary<string, int> finishAction()
    {
        // determine if action fails
        if (Random.Range(0, 101) > successChance) // 1d100 > successChance ?
        {
            this.rewards=this.failureRewards;
        }
        UpdateDataByNSake();
        return this.rewards;
    }

    public int getDaysToFinish()
    {
        return this.daysToFinish;
    }

    public int getTimeToDo()
    {
        return m_timeToDo;
    }

    public string getType()
    {
        return m_type;
    }

    public Dictionary<string, int> getRewardsDict()
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

    public void setRewardsDict(int wood, int food, int beaver, int sake, int beaver_dis, int human_dis)
    {
        this.rewards["Wood"] = wood;
        this.rewards["Food"] = food;
        this.rewards["Beaver"] = beaver;
        this.rewards["Sake"] = sake;
        this.rewards["Beaver_dis"] = beaver_dis;
        this.rewards["Human_dis"] = human_dis;
    }

    public void setFailureRewardsDict(int wood, int food, int beaver, int sake, int beaver_dis, int human_dis)
    {
        this.failureRewards["Wood"] = wood;
        this.failureRewards["Food"] = food;
        this.failureRewards["Beaver"] = beaver;
        this.failureRewards["Sake"] = sake;
        this.failureRewards["Beaver_dis"] = beaver_dis;
        this.failureRewards["Human_dis"] = human_dis;
    }

    public void DoAction()
    {
        //TODO - REVIEW: Delete this method if it is confirmed Deprecated
        switch (m_type)
        {
            case "village":
                setRewardsDict(0, 0, n_beavers, 2, 0, n_beavers / 2);
                break;
            case "field":
                setRewardsDict(m_wood, m_food, n_beavers, 0, m_wood / 2, 0);
                break;
            case "wood":
                setRewardsDict(m_wood, m_food, n_beavers, 0, m_wood / 2, 0);
                break;
            default:
                setRewardsDict(0, 0, 0, 0, 0, 0);
                break;
        }
    }

    private void UpdateDataByNBeavers()
    {
        var keys = rewards.Keys;
        foreach (var k in keys)
        {
            
        }
    }
    
    private void UpdateDataByNSake()
    {
        // Assuming each unit of sake increases rewards by 10%
        //TODO: Params can be moved to a SO
        var rewardsKeys = rewards.Keys;
        foreach (var k in rewardsKeys)
        {
            rewards[k] = Mathf.FloorToInt(rewards[k] * (1 + 0.1f* this.n_sake));
        }
    }




}
