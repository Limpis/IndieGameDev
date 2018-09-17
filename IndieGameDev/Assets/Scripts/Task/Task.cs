using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour {

    //Base class for every thinkable piece of work done in company.

    protected bool isActive = false;
    protected string taskName;
    protected int remainingProblems;
    protected Color taskColor = Color.cyan;

    public bool IsActive()
    {
        if(isActive)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetName()
    {
        return taskName;
    }

    public Color GetColor()
    {
        return taskColor;
    }

    public virtual void SolveProblem()
    {
        if (remainingProblems > 0)
        {
            remainingProblems--;
        }
        else
        {
            Debug.Log("Project finished! Follow up not implemented yet");
        }
    }

    protected void SetColor(Color c)
    {
        taskColor = c;
    }
}
