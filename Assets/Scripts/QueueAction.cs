using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueAction : MonoBehaviour
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


        foreach (Action action in this.queue)
        {
            if (action.doSelf())
            {
                Dictionary<string, int>  rewardAction = action.finishAction();
                rewards = addRessourceDictionaries(rewards, rewardAction);
                removeActionFromQueue(action);
            }
        }
        Debug.Log("Rewards\n");
        Debug.Log(rewards.ToString());
        return rewards;
    }

    public Dictionary<string, int> addRessourceDictionaries(Dictionary<string, int> dict, Dictionary<string, int> dictToAdd)
    {
        dict["Wood"] = dict["Wood"] + dictToAdd["Wood"];
        dict["Food"] = dict["Food"] + dictToAdd["Food"];
        dict["Beaver"] = dict["Beaver"] + dictToAdd["Beaver"];
        dict["Sake"] = dict["Sake"] + dictToAdd["Sake"];

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
}
