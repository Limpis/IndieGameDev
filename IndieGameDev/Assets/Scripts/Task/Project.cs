using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : Task {

    [Header("General Information")]
    [SerializeField]
    private int smallProjectProblems;
    [SerializeField]
    private int mediumProjectProblems, largeProjectProblems;
    [SerializeField]
    [Tooltip("A percentage number with which project size can scale from base value.")]
    private int projectSizeFluctuation;
    [SerializeField]
    Color solutionColor;

    private ProjectGUI gui;
    private int projectNumber = 0;
    //private bool activeProject;
    //private int remainingProblems;
    //private string projectName;
    
    public bool StartNewProject()
    {
        if(!base.isActive)
        {
            base.isActive = true;
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
        if (base.isActive)
        {
            switch (sizeIndex)
            {
                case 0:
                    CalculateInitialProblems(smallProjectProblems);
                    base.taskName = "sProjectNr" + projectNumber;
                    gui.SetProjectNameText(base.taskName);
                    break;
                case 1:
                    CalculateInitialProblems(mediumProjectProblems);
                    base.taskName = "mProjectNr" + projectNumber;
                    gui.SetProjectNameText(base.taskName);
                    break;
                case 2:
                    CalculateInitialProblems(largeProjectProblems);
                    base.taskName = "lProjectNr" + projectNumber;
                    gui.SetProjectNameText(base.taskName);
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

    public override void SolveProblem(int quality)
    {
        base.SolveProblem(quality);

        if(remainingProblems >= 0)
        {
            gui.UpdateProblemsProgress(remainingProblems, false);
        }

        gui.UpdateAverageQualityText(base.averageQuality);
    }

    public override void ShipTask()
    {
        //Create a product which has a value and sell it;
        Debug.Log(GetName() + " project has been put to the market");
    }

    private void Start()
    {
        gui = GetComponent<ProjectGUI>();
        base.isActive = false;
        base.SetColor(solutionColor);
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

    private IEnumerator progressTick()
    {
        while (remainingProblems > 0)
        {
            yield return new WaitForSeconds(1);

            remainingProblems--;
            gui.UpdateProblemsProgress(remainingProblems, false);
        }
    }

    protected override void TaskEnd()
    {
        base.TaskEnd();

        gui.ProjectFinished();
    }
}
