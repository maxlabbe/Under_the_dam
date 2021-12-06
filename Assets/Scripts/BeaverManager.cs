using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverManager : MonoBehaviour
{
    private const int START_BEAVERS_NUMBER = 5;
    [SerializeField] private List<Beaver> m_freeBeavers;
    [SerializeField] private List<Beaver> m_workingBeavers;
    [SerializeField] DayManager m_dayManager;

    void Start()
    {
        m_freeBeavers = new List<Beaver>();
        m_workingBeavers = new List<Beaver>();
        addBeavers(START_BEAVERS_NUMBER);
    }

    public void addBeavers(int numberOfBeavers)
    {
        for (int i = 0; i < numberOfBeavers; i++)
        {
            m_freeBeavers.Add(new Beaver());
        }
    }

    public void withdrawBeaver(Beaver beaver)
    {
        m_freeBeavers.Remove(beaver);
    }

    public int getNumberOfBeavers()
    {
        return m_freeBeavers.Count + m_workingBeavers.Count;
    }

    public int getFreeBeaversNumber()
    {
        return m_freeBeavers.Count;
    }

    public int getOccupiedBeaversNumber()
    {
        return m_workingBeavers.Count;
    }

    public void goToWork(int numberOfBeavers)
    {
        for(int i = 0; i < numberOfBeavers; i++)
        {
            m_freeBeavers[0].doSomething();
            m_workingBeavers.Add(m_freeBeavers[0]);
            m_freeBeavers.Remove(m_freeBeavers[0]);
        }
    }

    public void comeFromWork(int numberOfBeavers)
    {
        for (int i = 0; i < numberOfBeavers; i++)
        {
            m_workingBeavers[0].isResting();
            m_freeBeavers.Add(m_workingBeavers[0]);
            m_workingBeavers.Remove(m_workingBeavers[0]);
        }
    }

    public void LeavingBeavers()
    {
        float tauntValue = m_dayManager.getHumorManager().GetBeaversTauntValue();
        if(tauntValue > 50.0f )
        {
            int freeBeavers = getFreeBeaversNumber();
            float purcentageOfBeaverToLeave = (tauntValue - 40.0f)/100;
            int beaverToLeave = (int)(freeBeavers * purcentageOfBeaverToLeave);

            for (int i = 0; i < beaverToLeave; i++)
            {
                if(i < getFreeBeaversNumber())
                {
                    m_freeBeavers.Remove(m_freeBeavers[i]);
                }
            }
        }
    }

    public void ArrivingBeavers()
    {
        float tauntValue = m_dayManager.getHumorManager().GetHumansTauntValue();
        if (tauntValue > 20.0f)
        {
            int freeBeavers = getFreeBeaversNumber();
            float purcentageOfBeaverToCome = (tauntValue - 10.0f) / 100;
            int beaverToCome = (int)(freeBeavers * purcentageOfBeaverToCome);
            Debug.Log(beaverToCome);

            for (int i = 0; i < beaverToCome; i++)
            {
                if (i < getFreeBeaversNumber())
                {
                    m_freeBeavers.Add(new Beaver());
                }
            }
        }
    }
}
