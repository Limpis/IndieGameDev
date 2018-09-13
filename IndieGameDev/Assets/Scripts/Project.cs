using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour {

    [Header("General Information")]
    [SerializeField]
    private int smallProjectProblems;
    [SerializeField]
    private int mediumProjectProblems, largeProjectProblems;
    [SerializeField]
    [Tooltip("A percentage number with which project size can scale from base value.")]
    private int projectSizeFluctuation;

    private ProjectGUI gui;
    private int projectNumber = 0;
    private bool activeProject;
    private int remainingProblems;
    private string projectName;

    public bool StartNewProject()
    {
        if(!activeProject)
        {
            activeProject = true;
            projectNumber++;
            Debug.Log("New project started");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool InitializeProject(int sizeIndex)
    {
        if (activeProject)
        {
            switch (sizeIndex)
            {
                case 0:
                    CalculateInitialProblems(smallProjectProblems);
                    projectName = "sProjectNr" + projectNumber;
                    gui.SetProjectNameText(projectName);
                    break;
                case 1:
                    CalculateInitialProblems(mediumProjectProblems);
                    projectName = "mProjectNr" + projectNumber;
                    gui.SetProjectNameText(projectName);
                    break;
                case 2:
                    CalculateInitialProblems(largeProjectProblems);
                    projectName = "lProjectNr" + projectNumber;
                    gui.SetProjectNameText(projectName);
                    break;
                default:
                    Debug.Log("Error! Incorrect index set in project size button");
                    return false;
            }

            gui.UpdateProblemsProgress(remainingProblems, true);

            return true;
        }
        else
        {
            Debug.Log("Error! Trying to calculate project size when no project is active.");

            return false;
        }
    }

    public List<int> GetProjectSizeProblems()
    {
        List<int> list = new List<int>();

        list.Add(smallProjectProblems);
        list.Add(mediumProjectProblems);
        list.Add(largeProjectProblems);

        return list;
    }

    public void SolveProblem()
    {
        if(remainingProblems > 0)
        {
            remainingProblems--;
            gui.UpdateProblemsProgress(remainingProblems, false);
        }
        else
        {
            Debug.Log("Project finished! Follow up not implemented yet");
        }
    }

    public string GetProjectName()
    {
        return projectName;
    }

    public bool ProjectIsActive()
    {
        if(activeProject)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        gui = GetComponent<ProjectGUI>();
        activeProject = false;
    }

    private void CalculateInitialProblems(int baseSize)
    {
        //Calculation for randomizing initial amount of problems based on project size.
        int randomPositiveNumber = Random.Range(0, projectSizeFluctuation);
        int randomNegativeNumber = Random.Range(0, projectSizeFluctuation);

        float positiveFactor = randomPositiveNumber * 0.01f;
        float negativeFactor = randomNegativeNumber * 0.01f;

        float temp = baseSize + (baseSize * positiveFactor) - (baseSize * negativeFactor);

        remainingProblems = Mathf.RoundToInt(temp);
    }

    IEnumerator progressTick()
    {
        while (remainingProblems > 0)
        {
            yield return new WaitForSeconds(1);

            remainingProblems--;
            gui.UpdateProblemsProgress(remainingProblems, false);
        }
    }
}
