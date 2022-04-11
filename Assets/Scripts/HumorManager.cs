using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumorManager: MonoBehaviour{
    public static HumorManager instance { get; private set; }
    private float m_humans_gauge;
    private float m_beavers_gauge;

    private void Awake()
    {
        instance = this;
    }

    public HumorManager()
    {
        m_humans_gauge = 0f;
        m_beavers_gauge = 0f;
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
