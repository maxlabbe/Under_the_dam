using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodAction : Action
{
    private int wood_reward;
    public WoodAction(int p_beavers)
    {
        this.n_beavers = p_beavers;
        this.daysToFinish = 2;
        this.wood_reward = 20;
        initRewardDict();
        setRewardsDict(wood_reward * p_beavers,0,0,0,10,0);
    }
}
