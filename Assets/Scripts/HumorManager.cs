using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumorManager{
   
    private float m_humans_gauge;
    private float m_beavers_gauge;
    
    public HumorManager()
    {
        m_humans_gauge = 0f;
        m_beavers_gauge = 90f;
    }
    public float GetHumansTauntValue()
    {
        return m_humans_gauge;
    }

    public void AddHumansTaunt(float humans_taunt)
    {
        m_humans_gauge += humans_taunt;
    }
    public float GetBeaversTauntValue()
    {
        return m_beavers_gauge;
    }

    public void AddBeaversTaunt(float beavers_taunt)
    {
        m_beavers_gauge += beavers_taunt;
    }

}
