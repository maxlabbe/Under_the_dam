using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverManager : MonoBehaviour
{
    private const int START_BEAVERS_NUMBER = 5;
    [SerializeField] private List<Beaver> m_beavers;
    [SerializeField] DayManager m_dayManager;

    void Start()
    {
        m_beavers = new List<Beaver>();
        addBeavers(START_BEAVERS_NUMBER);
    }

    public void addBeavers(int numberOfBeavers)
    {
        for (int i = 0; i < numberOfBeavers; i++)
        {
            m_beavers.Add(new Beaver());
        }
    }

    public void withdrawBeaver(Beaver beaver)
    {
        m_beavers.Remove(beaver);
    }

    public int getNumberOfBeavers()
    {
        return m_beavers.Count;
    }

    public int getFreeBeaversNumber()
    {
        int freeBeaver = 0;
        for(int i = 0; i < m_beavers.Count; i++)
        {
            if(m_beavers[i].isFree())
            {
                freeBeaver++;
            }
        }

        return freeBeaver;
    }

    public int getOccupiedBeaversNumber()
    {
        return m_beavers.Count - getFreeBeaversNumber();
    }

    public void LeavingBeavers()
    {
        float tauntValue = m_dayManager.getHumorManager().GetBeaversTauntValue();
        if(tauntValue > 50 )
        {
            int freeBeavers = getFreeBeaversNumber();
            float purcentageOfBeaverToLeave = tauntValue - 40.0f;
        }
    }

    public void ArrivingBeavers()
    {

    }
}
