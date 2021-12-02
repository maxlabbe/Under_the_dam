using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesManager : MonoBehaviour
{
    private int m_wood;
    private int m_food;
    [SerializeField] private BeaverManager m_toothForce;
    private int m_sake;
    
    public int GetWood()
    {
        return this.m_wood;
    }

    public void AddWood(int wood)
    {
        this.m_wood += wood;
    }

    public void UseWood(int wood)
    {
        this.m_wood -= wood;
    }

    public int GetFood()
    {
        return this.m_food;
    }

    public void AddFood(int food)
    {
        this.m_food += food;
    }

    public void UseFood(int food)
    {
        this.m_food -= food;
    }

    public int GetToothForce()
    {
        return this.m_toothForce.getNumberOfBeavers();
    }

    public void AddToothForces(int toothForces)
    {
        this.m_toothForce.addBeavers(toothForces);
    }

    public void UseToothForces(int toothForces)
    {
        this.m_toothForce.goToWork(toothForces);
    }

    public int GetSake()
    {
        return this.m_sake;
    }

    public void AddSake(int sake)
    {
        this.m_sake += sake;
    }

    public void UseSake(int sake)
    {
        this.m_sake -= sake;
    }


}
