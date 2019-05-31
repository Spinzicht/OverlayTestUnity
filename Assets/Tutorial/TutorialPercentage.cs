using Ludio.Data;
using Ludio.Data.Tasks;
using Ludio.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPercentage : MonoBehaviour {

    Text t;
    int currentStep;
    int totalSteps;
    Iterator root;

    // Use this for initialization
    void Start () {
        t = GetComponent<Text>();
        root = DATA.GLOBAL.Task.CreateIterator();
        totalSteps = GetStepCount(root);

        t.text = totalSteps.ToString();
    }

    int GetStepCount(Iterator it)
    {
        int c = it.Length;
        for(it.First(); !it.IsDone(); it.Next())
        {
            c += GetStepCount(((Activity)it.Current).CreateIterator());
        }
        return c;
    }

    int GetStepCount2(Iterator it, bool done = false)
    {
        int c = 0;
        for (it.First(); !it.IsDone(); it.Next())
        {
            bool d = done || ((Task)it.Current).IsDone;
            if (d) c++;
            c += GetStepCount2(((Activity)it.Current).CreateIterator(), d);
        }
        return c;
    }

    // Update is called once per frame
    void Update () {
        var stepsDone = GetStepCount2(root);
        t.text = Math.Round(((float)stepsDone / totalSteps * 100)) + "%"; 
	}
}
