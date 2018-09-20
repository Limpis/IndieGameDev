using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanySalaries : MonoBehaviour
{

    //Used to adjust economy for all agents when salaries are paid.

    private List<GameObject> agents;
    private Capital capital;

    public void SetAgents(List<GameObject> a)
    {
        agents = a;
    }

    public void PaySalaries()
    {
        Economy economy;

        for (int i = 0; i < agents.Count; i++)
        {
            economy = agents[i].GetComponent<Economy>();

            capital.RemoveMoney(economy.GetSalary());
            economy.PayDay();
        }
    }

    private void Start()
    {
        capital = GetComponent<Capital>();
    }
}
