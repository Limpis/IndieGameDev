using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawn : MonoBehaviour {

    [SerializeField]
    private GameObject agentPrefab;

    [Header("Setup")]
    [SerializeField]
    private int agentCount;
    [SerializeField]
    private Transform[] spawnPositions;

    [Header("Appearance")]
    [SerializeField]
    private Color[] possibleShirtColors;
    [SerializeField]
    private Color[] possibleSkinColors;

    private List<GameObject> agents = new List<GameObject>();
    private CompanySalaries salaries;

    public List<GameObject> GetAgents()
    {
        return agents;
    }

    private void Start()
    {
        salaries = GameObject.FindGameObjectWithTag("Capital").GetComponent<CompanySalaries>();

        SpawnAgents();
    }

    private void SpawnAgents()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            if(agentCount > spawnPositions.Length)
            {
                Debug.Log("Error! Unable to spawn up to agenCount, not enough spawn positions.");
            }
            else if(i >= agentCount)
            {
                return;
            }

            GameObject newAgent = Instantiate(agentPrefab, spawnPositions[i]);
            SetAgentColor(newAgent);
            agents.Add(newAgent);
        }

        UpdateCompanySalaries();
    }

    private void SetAgentColor(GameObject agent)
    {
        Appearance appearance = agent.GetComponent<Appearance>();

        Color colorBody = RandomizeColor(possibleShirtColors);
        Color colorSkin = RandomizeColor(possibleSkinColors);

        appearance.SetColors(colorBody, colorSkin);
    }

    private Color RandomizeColor(Color[] possibleColors)
    {
        int randomNumber = Random.Range(0, possibleColors.Length);
        Color c = possibleColors[randomNumber];

        return c;
    }

    private void UpdateCompanySalaries()
    {
        salaries.SetAgents(agents);
    }
}
