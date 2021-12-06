using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Action
{
    public Choice choiceData;
    public int daysToFinish; //Jours restants pour finir l'action
    public int m_timeToDo; //Valeur intiale de daysToFinish
    private bool inProg; //L'action est en cours ou non
    private int successChance; //Est déterminé à partir de Choice.probability
    private string m_type;
    private Dictionary<string, int> rewards; //
    private Dictionary<string, int> failureRewards; //
    private Dictionary<string, int> used_ressources; //

    //TODO - Edit: configurable daysToFinish,     (=>OK)
    //TODO - Implement: Rewards when the action fails,       (=>OK)
    //TODO - Implement: determine success/failure when resolving the action,      (=>REVIEW)
    //TODO - Implement: sake amount can affect [reward amount],[time to resolve (?)] etc.    
    //TODO - Implement: number of beaver assigned can affect [success chance], [time to resolve (?)], etc. (=> REVIEW)

    public Action(Choice choice, Dictionary<string, int> used_ressources)
    {
        choiceData = choice;
        rewards = new Dictionary<string, int>();
        failureRewards = new Dictionary<string, int>();
        this.used_ressources = used_ressources;
        
        RessourcesManager.instance.UseFood(used_ressources["food"]);
        RessourcesManager.instance.UseWood(used_ressources["wood"]);
        RessourcesManager.instance.UseSake(used_ressources["sake"]);
        RessourcesManager.instance.m_toothForce.goToWork(used_ressources["beaver"]);

        foreach (Choice.results res in choiceData.rewards)
        {
            rewards.Add(res.type, res.value);
        }
        foreach (Choice.results fai in choiceData.fail)
        {
            failureRewards.Add(fai.type, fai.value);
        }
        // this.daysToFinish = choiceData.time;
        choice.dayToFinish = (daysToFinish == 0) ? 3 : choice.dayToFinish;
        m_timeToDo = choice.dayToFinish - used_ressources["beaver"]/choice.dayToFinish + 1;
        this.daysToFinish = m_timeToDo;
        this.rewards["beaver_dis"] *= daysToFinish ;
        this.inProg = true;
        successChance = Mathf.FloorToInt(choiceData.probability*100);
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
        // UpdateDataByNSake();
        RessourcesManager.instance.m_toothForce.comeFromWork(used_ressources["beaver"]);
        if (Random.Range(0, 101) > successChance) // 1d100 > successChance ?
        {
            return this.failureRewards;
        }
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

    public bool getType()
    {
        return choiceData.isAttack;
    }

    // public Dictionary<string, int> getRewardsDict()
    // {
    //     return this.rewards;
    // }

    // public int getNBeavers()
    // {
    //     return this.n_beavers;
    // }

    // public void initRewardDict()
    // {
    //     this.rewards.Add("Wood", 0);
    //     this.rewards.Add("Food", 0);
    //     this.rewards.Add("Beaver", 0);
    //     this.rewards.Add("Sake", 0);
    //     this.rewards.Add("Beaver_dis", 0);
    //     this.rewards.Add("Human_dis", 0);
    // }

    // public void setRewardsDict(int wood, int food, int beaver, int sake, int beaver_dis, int human_dis)
    // {
    //     this.rewards["Wood"] = wood;
    //     this.rewards["Food"] = food;
    //     this.rewards["Beaver"] = beaver;
    //     this.rewards["Sake"] = sake;
    //     this.rewards["Beaver_dis"] = beaver_dis;
    //     this.rewards["Human_dis"] = human_dis;
    // }

    // public void setFailureRewardsDict(int wood, int food, int beaver, int sake, int beaver_dis, int human_dis)
    // {
    //     this.failureRewards["Wood"] = wood;
    //     this.failureRewards["Food"] = food;
    //     this.failureRewards["Beaver"] = beaver;
    //     this.failureRewards["Sake"] = sake;
    //     this.failureRewards["Beaver_dis"] = beaver_dis;
    //     this.failureRewards["Human_dis"] = human_dis;
    // }

    // public void DoAction()
    // {

    //     //TODO - REVIEW: Delete this method if it is confirmed Deprecated
    //     switch (m_type)
    //     {
    //         case "village":
    //             setRewardsDict(0, 0, n_beavers, 2, 0, n_beavers / 2);
    //             break;
    //         case "field":
    //             setRewardsDict(m_wood, m_food, n_beavers, 0, m_wood / 2, 0);
    //             break;
    //         case "wood":
    //             setRewardsDict(m_wood, m_food, n_beavers, 0, m_wood / 2, 0);
    //             break;
    //         default:
    //             setRewardsDict(0, 0, 0, 0, 0, 0);
    //             break;
    //     }
    // }

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
         var rewardsKeys = new List<string>(rewards.Keys.ToList());
         foreach (var k in rewardsKeys)
         {
            //  rewards[k] = Mathf.FloorToInt(rewards[k] * (1 + 0.1f * used_ressources["sake"]));
         }
    }




}
