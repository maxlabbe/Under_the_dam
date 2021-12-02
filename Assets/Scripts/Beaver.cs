using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaver
{ 
    private bool m_isWorking;

    public Beaver()
    {
        m_isWorking = false;
    }
    public bool isFree()
    {
        return m_isWorking;
    }

    public void doSomething()
    {
        m_isWorking = true;
    }

    public void isResting()
    {
        m_isWorking = false;
    }
}
