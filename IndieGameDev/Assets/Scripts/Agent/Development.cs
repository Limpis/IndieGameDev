﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Development : MonoBehaviour {

    [SerializeField]
    private Transform solutionSpawn;
    [SerializeField]
    private float baseProductionSpeed;
    [SerializeField]
    private int solutionBaseQuality;
    [SerializeField]
    GameObject solutionPrefab;

    private GameObject workedTask;
    private List<GameObject> availableTasks;

    private AgentGUI gui;
    private Personality personality;
    private Motivation motivation;

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
        else if(availableTasks.Count <= 0)
        {
            gui.ClearDropdown();
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
        motivation = GetComponent<Motivation>();
    }

    private IEnumerator ProblemSolving(GameObject startTask)
    {
        yield return new WaitForSeconds(baseProductionSpeed);

        while (workedTask == startTask)
        {
            GameObject solution = Instantiate(solutionPrefab, solutionSpawn);
            solution.GetComponent<Solution>().SetTarget(workedTask);
            solution.GetComponent<SolutionData>().SolutionQuality = CalculateQuality();

            WaitForSeconds prodSpeed = new WaitForSeconds(motivation.MotivationSpeedEffect(baseProductionSpeed));
            yield return prodSpeed;
        }
    }

    private int CalculateQuality()
    {
        int solutionQuality = solutionBaseQuality;

        solutionQuality = personality.SkillQualityEffect(solutionQuality);
        solutionQuality = motivation.MotivationQualityEffect(solutionQuality);

        return solutionQuality;
    }
}
