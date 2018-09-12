using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Development : MonoBehaviour {

    [SerializeField]
    private Transform solutionSpawn;
    [SerializeField]
    GameObject workedTask, solutionPrefab;

    private AgentGUI gui;
    private List<GameObject> availableTasks;

    private void Start()
    {
        gui = GetComponent<AgentGUI>();
    }

    private void Update()
    {
        //Remove from update into its own development tick.
        //Only update dropdown IF tasks are found
        availableTasks = new List<GameObject>();
        availableTasks.AddRange(GameObject.FindGameObjectsWithTag("Task"));
        gui.PopulateDropDown(availableTasks);
    }

    private IEnumerator ProblemSolving()
    {
        while (workedTask != null)
        {
            yield return new WaitForSeconds(3f);

            GameObject solution = Instantiate(solutionPrefab, solutionSpawn);
            solution.GetComponent<Solution>().SetTarget(workedTask);
        }
    }
}
