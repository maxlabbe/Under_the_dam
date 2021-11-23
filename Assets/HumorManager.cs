using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumorManager : MonoBehaviour
{
    private int m_humans_gauge;
    private int m_beavers_gauge;
    
    public int GetHumansTauntValue()
    {
        return m_humans_gauge;
    }

    public void AddHumansTaunt(int humans_taunt)
    {
        m_humans_gauge += humans_taunt;
    }
    public int GetBeaversTauntValue()
    {
        return m_beavers_gauge;
    }

    public void AddBeaversTaunt(int beavers_taunt)
    {
        m_beavers_gauge += beavers_taunt;
    }

}
