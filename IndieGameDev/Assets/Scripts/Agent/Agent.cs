using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeveloperRole
{
    Designer,
    Programmer,
    Artist
};

public class Agent : MonoBehaviour {

    //Holds general information about the agent such as name, age and developer role.

    [Header("General Information")]
    [SerializeField]
    private string agentName;
    [SerializeField]
    private int agentAge;
    [SerializeField]
    private DeveloperRole agentRole;

}
