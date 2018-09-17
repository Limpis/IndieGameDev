using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality : MonoBehaviour {

    [SerializeField]
    private int developmentSkill;

    public int GetSkill()
    {
        return developmentSkill;
    }
}
