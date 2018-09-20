using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motivation : MonoBehaviour {

    //Every agent has an individual motivation value.
    //Motivation affects work speed and quality of solutions.

    [SerializeField]
    private int minMotivation = 0, maxMotivation = 0;
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

    public float MotivationSpeedEffect(float productionSpeed)
    {
        //Motivation is above mid, increase production speed.
        if((agentMotivation - Mathf.Lerp(minMotivation, maxMotivation, 0.5f)) > 0)
        {
            float speedChange = (agentMotivation - Mathf.Lerp(minMotivation, maxMotivation, 0.5f));
            speedChange = speedChange / 2;
            productionSpeed = productionSpeed - (speedChange * 0.1f);
        }

        //Motivation is below mid, decrease production speed.
        else if((agentMotivation - Mathf.Lerp(minMotivation, maxMotivation, 0.5f)) <= 0)
        {
            float speedChange = (agentMotivation - Mathf.Lerp(minMotivation, maxMotivation, 0.5f));
            speedChange = speedChange / 2;
            productionSpeed = productionSpeed - (speedChange * 0.1f);
        }

        Debug.Log("Waiting for: " + productionSpeed + " seconds.");
        return productionSpeed;
    }

    private void Start()
    {
        RandomizeMotivation();
    }

    private void RandomizeMotivation()
    {
        agentMotivation = Random.Range(minMotivation, maxMotivation);
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
