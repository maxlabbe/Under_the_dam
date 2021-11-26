using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{
    private int m_wood;
    private int m_food;
    private int m_toothForce;
    private int m_sake;
    
    public int GetWood()
    {
        return m_wood;
    }

    public void AddWood(int wood)
    {
        m_wood += wood;
    }

    public void UseWood(int wood)
    {
        m_wood -= wood;
    }

    public int Getfood()
    {
        return m_food;
    }

    public void AddFood(int food)
    {
        m_food += food;
    }

    public void UseFood(int food)
    {
        m_food -= food;
    }

    public int GetToothForce()
    {
        return m_toothForce;
    }

    public void AddToothForces(int toothForces)
    {
        m_toothForce += toothForces;
    }

    public void UseToothForces(int toothForces)
    {
        m_toothForce -= toothForces;
    }

    public int GetSake()
    {
        return m_sake;
    }

    public void AddSake(int sake)
    {
        m_sake += sake;
    }

    public void UseSake(int sake)
    {
        m_sake -= sake;
    }
}
