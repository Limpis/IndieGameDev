using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality : MonoBehaviour {

    [SerializeField]
    private int minDevSkill = 0, maxDevSkill = 0;
    [SerializeField]
    [Range(0f, 1.0f)]
    private float qualityVariationPercentage;

    private int developmentSkill;

    public int DevelopmentSkill { get; set; }

    public int SkillQualityEffect(int quality)
    {
        int solutionQuality = (quality + developmentSkill) / 2;
        solutionQuality = QualityVariation(solutionQuality);

        Debug.Log("Quality after skill check: " + solutionQuality);

        return solutionQuality;
    }

    private void Start()
    {
        RandomizeSkill();
    }

    private void RandomizeSkill()
    {
        developmentSkill = Random.Range(minDevSkill, maxDevSkill);
        GetComponent<AgentGUI>().SetSkillText(developmentSkill); //Look for implementations separating update of GUI.
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
