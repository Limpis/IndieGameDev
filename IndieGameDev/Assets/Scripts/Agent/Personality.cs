using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality : MonoBehaviour {

    [SerializeField]
    private int minDevSkill, maxDevSkill;

    private int developmentSkill;

    public int GetSkill()
    {
        return developmentSkill;
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
}
