using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour{

    int daysToFinish;
    bool inProg;
    // Start is called before the first frame update
    void Start()
    {
        this.inProg = true;
        this.daysToFinish = 1;
        Debug.Log("Acrion init");
    }

    // Update is called once per frame
    void Update(){}

    void continueAction(){
        daysToFinish--;
        if(daysToFinish == 0)
        {
            this.finishAction();
        }
    }

    void finishAction()
    {
        this.inProg = false;
        Debug.Log("Acrion done");
    }
}
