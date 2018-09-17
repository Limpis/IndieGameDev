﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Development : MonoBehaviour {

    [SerializeField]
    private Transform solutionSpawn;
    [SerializeField]
    GameObject solutionPrefab;

    private GameObject workedTask;
    private AgentGUI gui;
    private Personality personality;
    private List<GameObject> availableTasks;

    public void AgentTick()
    {
        //Method used for updating task status and improving game performance.

        availableTasks = new List<GameObject>();
        availableTasks.AddRange(GameObject.FindGameObjectsWithTag("Task"));

        //Remove inactive tasks
        for (int i = 0; i < availableTasks.Count; i++)
        {
            if (!availableTasks[i].GetComponent<Task>().IsActive())
            {
                availableTasks.Remove(availableTasks[i]);
            }
        }

        if (availableTasks.Count > 0)
        {
            gui.PopulateDropDown(availableTasks);
        }

        //Assign worked task according to dropdown menu in GUI.
        if (gui.GetActiveTask() != null && gui.GetActiveTask() != workedTask)
        {
            workedTask = gui.GetActiveTask();
            StartCoroutine(ProblemSolving(workedTask));
            Debug.Log("Worked task is now: " + workedTask.GetComponent<Task>().GetName());
        }
        else if (gui.GetActiveTask() == null && workedTask != null)
        {
            workedTask = null;
            Debug.Log("Worked task is now: None");
        }
    }

    private void Start()
    {
        gui = GetComponent<AgentGUI>();
        personality = GetComponent<Personality>();
    }

    private IEnumerator ProblemSolving(GameObject startTask)
    {
        while (workedTask == startTask)
        {
            GameObject solution = Instantiate(solutionPrefab, solutionSpawn);
            solution.GetComponent<Solution>().SetTarget(workedTask);
            Debug.Log("Skill is: " + personality.GetSkill());
            solution.GetComponent<SolutionData>().SolutionQuality = personality.GetSkill();

            yield return new WaitForSeconds(3f);
        }
    }
}
