using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectGUI : MonoBehaviour {

    [Header("GUI Panels")]
    [SerializeField]
    private GameObject projectNewPanel;
    [SerializeField]
    private GameObject projectSizePanel, projectProgressPanel, projectCompletePanel;

    [Header("Size Buttons")]
    [SerializeField]
    private List<GameObject> ProjectSizeAverageProblemsText;

    [Header("Project Progress")]
    [SerializeField]
    private GameObject projectNameText;
    [SerializeField]
    private GameObject projectProblemsText, projectAverageQualityText, progressBar;

    private Project project;
    private int initialProblems, remainingProblems;

    public void NewProjectButtonClick()
    {
        if(!project.IsActive())
        {
            projectNewPanel.SetActive(false);
            projectSizePanel.SetActive(true);
        }
        else
        {
            Debug.Log("Error! Trying to start a new project while project already active.");
        }
    }

    public void SizeButtonClick(int sizeIndex)
    {
        //Start new project and initialize size.
        if (project.StartNewProject())
        {
            if (project.InitializeProject(sizeIndex))
            {
                projectSizePanel.SetActive(false);
                projectProgressPanel.SetActive(true);
            }
            else
            {
                Debug.Log("Error! Failed calculating size of project");
            }
        }
        else
        {
            Debug.Log("Error! Trying to start a new project while project already active.");
        }
    }

    public void ShipButtonClick()
    {
        project.ShipTask();

        InitializeGUI();
    }

    public void SetProjectNameText(string name)
    {
        projectNameText.GetComponent<Text>().text = name;
    }

    public void UpdateProblemsProgress(int problems, bool newProject)
    {
        //update text and call for calculating slider
        if(newProject)
        {
            initialProblems = problems;
        }

        remainingProblems = problems;

        projectProblemsText.GetComponent<Text>().text = "Problems Remaining: " + remainingProblems;
        progressBar.GetComponent<Slider>().value = CalculateSliderPosition();
    }

    public void UpdateAverageQualityText(int quality)
    {
        projectAverageQualityText.GetComponent<Text>().text = "Average Quality: " + quality.ToString();
    }

    public void ProjectFinished()
    {
        projectCompletePanel.SetActive(true);
    }

    private void Start()
    {
        project = GetComponent<Project>();

        InitializeGUI();
    }

    private void InitializeGUI()
    {
        projectNewPanel.SetActive(true);
        projectSizePanel.SetActive(false);
        projectProgressPanel.SetActive(false);
        projectCompletePanel.SetActive(false);

        //Initialize problems per size text labels
        List<int> list = project.GetProjectSizeProblems();
        for (int i = 0; i < list.Count; i++)
        {
            ProjectSizeAverageProblemsText[i].GetComponent<Text>().text = "~" + list[i].ToString() + " problems";
        }
    }

    private float CalculateSliderPosition()
    {
        float value = Mathf.InverseLerp(initialProblems, 0f, remainingProblems);

        return value;
    }
}
