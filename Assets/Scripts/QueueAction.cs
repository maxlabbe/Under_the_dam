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
        var rewards = new Dictionary<string, int>
        {
            { "wood", 0 },
            { "food", 0 },
            { "beaver", 0 },
            { "sake", 0 },
            { "beaver_dis", 0 },
            { "human_dis", 0 }
        };
        
        foreach (var action in queue)
        {
            if (!action.doSelf()) continue;
            var  rewardAction = action.finishAction();
            rewards = addRessourceDictionaries(rewards, rewardAction);
            removeActionFromQueue(action);
        }
        return rewards;
    }

    public Dictionary<string, int> addRessourceDictionaries(Dictionary<string, int> dict, Dictionary<string, int> dictToAdd)
    {
        var keys = dict.Keys;
        foreach (var k in keys)
        {
            dict[k] += dictToAdd[k];
        }

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
