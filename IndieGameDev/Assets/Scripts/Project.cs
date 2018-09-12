using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour {

    [Header("General Information")]
    [SerializeField]
    private int smallProjectProblems;
    [SerializeField]
    private int mediumProjectProblems, largeProjectProblems;

    private bool activeProject;

    public bool StartNewProject()
    {
        if(!activeProject)
        {
            activeProject = true;
            Debug.Log("New project started");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void InitializeSmallProject()
    {

    }

    public void InitializeMediumProject()
    {

    }

    public void InitializeLargeProject()
    {

    }

    public List<int> GetProjectSizeProblems()
    {
        List<int> list = new List<int>();

        list.Add(smallProjectProblems);
        list.Add(mediumProjectProblems);
        list.Add(largeProjectProblems);

        return list;
    }

    private void Start()
    {
        activeProject = false;
    }
}
