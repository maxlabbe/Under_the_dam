using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniActionManager : MonoBehaviour
{
    private List<Action> m_actionsInQueue;
    [SerializeField] private GameObject[] m_miniEmplacements;
    [SerializeField] private Sprite m_attackSprite, m_ressourcesSprite;

    public void Start()
    {
        m_actionsInQueue = new List<Action>();
    }
    public void Show()
    {
        if(m_actionsInQueue.Count < m_miniEmplacements.Length)
        {
            for (int actionIndex = 0; actionIndex < m_actionsInQueue.Count; actionIndex++)
            {
                m_miniEmplacements[actionIndex].SetActive(true);
            }
        }
        else
        {
            for (int actionIndex = 0; actionIndex < m_miniEmplacements.Length; actionIndex++)
            {
                m_miniEmplacements[actionIndex].SetActive(true);
            }
        }
        
    }

    public void Hide()
    {
        for (int actionIndex = 0; actionIndex < m_miniEmplacements.Length; actionIndex++)
        {
            m_miniEmplacements[actionIndex].SetActive(false);
        }
    }

    public void UpdateMinis(List<Action> actions)
    {
        m_actionsInQueue = actions;

        int numberOfActions = m_actionsInQueue.Count;

        if(numberOfActions < m_miniEmplacements.Length)
        {
            for (int actionIndex = 0; actionIndex < numberOfActions; actionIndex++)
            {
                float daysToFinish = m_actionsInQueue[actionIndex].daysToFinish;
                float timeToDo = m_actionsInQueue[actionIndex].getTimeToDo();
                float advancement = daysToFinish / timeToDo;

                m_miniEmplacements[actionIndex].GetComponentInChildren<Image>().fillAmount = 1.0f - advancement;
                if (m_actionsInQueue[actionIndex].getType() == "village")
                {
                    m_miniEmplacements[actionIndex].GetComponent<SpriteRenderer>().sprite = m_attackSprite;
                    m_miniEmplacements[actionIndex].GetComponentInChildren<Image>().color = Color.red;
                }
                else
                {
                    m_miniEmplacements[actionIndex].GetComponent<SpriteRenderer>().sprite = m_ressourcesSprite;
                    m_miniEmplacements[actionIndex].GetComponentInChildren<Image>().color = Color.green;
                }
            }

            for(int actionIndex = numberOfActions; actionIndex < m_miniEmplacements.Length; actionIndex++)
            {
                m_miniEmplacements[actionIndex].SetActive(false);
            }
        }

        else
        {
            for (int actionIndex = 0; actionIndex < m_miniEmplacements.Length; actionIndex++)
            {
                float daysToFinish = m_actionsInQueue[actionIndex].daysToFinish;
                float timeToDo = m_actionsInQueue[actionIndex].getTimeToDo();
                float advancement = daysToFinish / timeToDo;

                m_miniEmplacements[actionIndex].GetComponentInChildren<Image>().fillAmount = 1.0f - advancement;

                if (m_actionsInQueue[actionIndex].getType() == "village")
                {
                    m_miniEmplacements[actionIndex].GetComponent<SpriteRenderer>().sprite = m_attackSprite;
                    m_miniEmplacements[actionIndex].GetComponentInChildren<Image>().color = Color.red;
                }
                else
                {
                    m_miniEmplacements[actionIndex].GetComponent<SpriteRenderer>().sprite = m_ressourcesSprite;
                    m_miniEmplacements[actionIndex].GetComponentInChildren<Image>().color = Color.green;
                }
            }
        }
        
    }
}
