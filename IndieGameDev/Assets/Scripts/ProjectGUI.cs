using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectGUI : MonoBehaviour {

    [SerializeField]
    private GameObject projectNewPanel, projectSizePanel, projectProgressPanel;
    [SerializeField]
    private List<GameObject> projectSizeProblemsText;

    private Project project;

    public void NewProjectButtonClick()
    {
        if(project.StartNewProject())
        {
            projectNewPanel.SetActive(false);
            projectSizePanel.SetActive(true);
        }
        else
        {
            Debug.Log("Error! Trying to start a new project while project already active.");
        }
    }

    public void SizeSmallButtonClick()
    {

    }

    public void SizeMediumButtonClick()
    {

    }

    public void SizeLargeButtonClick()
    {

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

        //Initialize problems per size text labels
        List<int> list = project.GetProjectSizeProblems();
        for (int i = 0; i < list.Count; i++)
        {
            projectSizeProblemsText[i].GetComponent<Text>().text = "~" + list[i].ToString() + " problems";
        }
    }
}
