using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueAction
{
    private List<Action> queue;

    public QueueAction()
    {
        this.queue = new List<Action>();
    }

    public Dictionary<string,int> doAllActions()
    {
        Dictionary<string, int> rewards = new Dictionary<string, int>();
        rewards.Add("Wood",   0);
        rewards.Add("Food",   0);
        rewards.Add("Beaver", 0);
        rewards.Add("Sake",   0);
        rewards.Add("Beaver_dis", 0);
        rewards.Add("Human_dis", 0);


        foreach (Action action in this.queue.ToArray())
        {
            if (action.doSelf())
            {
                Dictionary<string, int>  rewardAction = action.finishAction();
                rewards = addRessourceDictionaries(rewards, rewardAction);
                removeActionFromQueue(action);
            }
        }
        //Debug.Log("Rewards\n");
        //Debug.Log(rewards.ToString());
        Debug.Log("     Queue has " + this.queue.Count + " actions");
        return rewards;
    }

    public Dictionary<string, int> addRessourceDictionaries(Dictionary<string, int> dict, Dictionary<string, int> dictToAdd)
    {
        dict["Wood"] = dict["Wood"] + dictToAdd["Wood"];
        dict["Food"] = dict["Food"] + dictToAdd["Food"];
        dict["Beaver"] = dict["Beaver"] + dictToAdd["Beaver"];
        dict["Sake"] = dict["Sake"] + dictToAdd["Sake"];
        dict["Beaver_dis"] = dict["Beaver_dis"] + dictToAdd["Beaver_dis"];
        dict["Human_dis"] = dict["Human_dis"] + dictToAdd["Human_dis"];

        return dict;
    }

    public List<Action> getQueueList()
    {
        return this.queue;
    }

    public void removeActionFromQueue(Action a)
    {
        this.queue.Remove(a);
    }

    public void addActionToQueue(Action a)
    {
        Debug.Log("Added action to queue (from QueueAction.cs");
        this.queue.Add(a);
    }

    override
    public string ToString()
    {
        string toString="";
        int i = 0;

        foreach(Action a in this.queue)
        {
            toString += i+" : "+a.getDaysToFinish() + "\n";
        }

        return toString;
    }
}
