using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motivation : MonoBehaviour {

    //Every agent has an individual motivation value.
    //Motivation affects work speed and quality of solutions.

    [SerializeField]
    private int minStartMotivation, maxStartMotivation;
    [SerializeField]
    [Range(0f, 1.0f)]
    private float qualityVariationPercentage;

    private int agentMotivation;

    public int AgentMotivation { get; set; }

    public int MotivationQualityEffect(int quality)
    {
        //Recieve base quality and calculate motivation's effect on solution quality.
        int solutionQuality = (quality + (agentMotivation / 2)) / 2;
        solutionQuality = QualityVariation(solutionQuality);

        Debug.Log("Quality after motivation check: " + solutionQuality);
        return solutionQuality;
    }

    private void Start()
    {
        RandomizeMotivation();
    }

    private void RandomizeMotivation()
    {
        agentMotivation = Random.Range(minStartMotivation, maxStartMotivation);
        GetComponent<AgentGUI>().SetMotivationText(agentMotivation);
    }

    private int QualityVariation(int quality)
    {
        //Method used for randomizing variation in quality.
        float randomPercentage = Random.Range(0f, qualityVariationPercentage);
        float floatValue = quality + (quality * randomPercentage);

        randomPercentage = Random.Range(0f, qualityVariationPercentage);
        floatValue = floatValue - (quality * randomPercentage);

        int solutionQuality = (int)floatValue;

        return solutionQuality;
    }
}
