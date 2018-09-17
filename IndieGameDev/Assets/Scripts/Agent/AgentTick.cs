using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentTick : MonoBehaviour {

    //Note! AgentTick is NOT the same as solution production speed
    //but instead method called instead of Update() for optimization purposes.

    [SerializeField]
    [Tooltip("Seconds per agent tick.")]
    private float tickSpeed;

    private List<GameObject> agents;
    private WaitForSeconds wait;

    private void Start()
    {
        wait = new WaitForSeconds(tickSpeed);
        StartCoroutine(Counter());
    }

    private void AgentUpdateTick()
    {
        if(agents == null)
        {
            agents = GetComponent<AgentSpawn>().GetAgents();
        }

        for (int i = 0; i < agents.Count; i++)
        {
            agents[i].GetComponent<Development>().AgentTick();
        }
    }

    private IEnumerator Counter()
    {
        while (true)
        {
            yield return wait;

            AgentUpdateTick();
        }
    }
}
