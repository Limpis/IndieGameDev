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

    private bool activeProject;
    private float remainingProblems;

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

    public void InitializeProject(int sizeIndex)
    {
        if (activeProject)
        {
            switch (sizeIndex)
            {
                case 0:
                    CalculateInitialProblems(smallProjectProblems);
                    break;
                case 1:
                    CalculateInitialProblems(mediumProjectProblems);
                    break;
                case 2:
                    CalculateInitialProblems(largeProjectProblems);
                    break;
                default:
                    Debug.Log("Error! Incorrect index set in project size button");
                    break;
            }
        }
        else
        {
            Debug.Log("Error! Trying to set project size when no project is active.");
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

    private void Start()
    {
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
        Debug.Log("Initial problems set to: " + remainingProblems);
    }
}
