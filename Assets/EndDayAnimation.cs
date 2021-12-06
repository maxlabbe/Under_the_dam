using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayAnimation : MonoBehaviour
{
    [SerializeField] GameObject m_table;
    [SerializeField] GameObject m_office;
    [SerializeField] GameObject m_dream;
    [SerializeField] GameObject endDayReport;

    // Update is called once per frame
    public void endDayAnimation()
    {
        m_table.SetActive(true);
        m_office.SetActive(true);
        m_dream.SetActive(true);

        m_table.GetComponent<Animation>().Stop();
        m_office.GetComponent<Animation>().Stop();
        m_dream.GetComponent<Animation>().Stop();

        m_table.GetComponent<Animation>().Play();
        m_office.GetComponent<Animation>().Play();
        m_dream.GetComponent<Animation>().Play();

        StartCoroutine(waitForAnimationToRun());
        
        StopCoroutine(waitForAnimationToRun());
    }

    IEnumerator waitForAnimationToRun()
    {
        yield return new WaitForSeconds(m_dream.GetComponent<Animation>().clip.length - 0.5f);
        endDayReport.SetActive(true);
    }
}
