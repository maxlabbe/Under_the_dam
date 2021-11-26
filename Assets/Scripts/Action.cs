using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{

    public int daysToFinish;
    private int m_timeToDo;
    private bool inProg;
    private int m_wood;
    private int m_food;
    private string m_type;
    public int n_beavers;
    private Dictionary<string, int> rewards;

    public Action(int wood, int food, string type)
    {
        m_wood = wood;
        m_food = food;
        n_beavers = 5;
        m_type = type;
        this.rewards = new Dictionary<string, int>();
        this.daysToFinish = 3;
        this.m_timeToDo = this.daysToFinish;
        this.inProg = true;
        this.rewards.Add("Wood", 0);
        this.rewards.Add("Food", 0);
        this.rewards.Add("Beaver", 0);
        this.rewards.Add("Sake", 0);
        this.rewards.Add("Beaver_dis", 0);
        this.rewards.Add("Human_dis", 0);
    }

    public bool doSelf()
    {
        this.daysToFinish--;
        if (this.daysToFinish <= 0)
        {
            this.inProg = false;
        }
        return !this.inProg;
    }


    public Dictionary<string, int> finishAction()
    {
        DoAction();
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

    public void DoAction()
    {
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
}
