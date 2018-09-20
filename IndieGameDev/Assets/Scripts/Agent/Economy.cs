using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economy : MonoBehaviour {

    //Script for handling an agents personal economy i.e. saldo, salary & expenses.
    [SerializeField]
    private int agentSalary = 0;
    [SerializeField]
    private int agentSaldo = 0; //Saldo is only seen as a rough estimation for calculating how long an agent could live without salary.
    [SerializeField]
    private int montlyExpenses = 0; //Information only visible in game as rough estimation - tied closely with life quality.

    public int GetSalary()
    {
        return agentSalary;
    }

    public void SetSalary(int salary)
    {
        agentSalary = salary;
    }

    public void PayDay()
    {
        //Give agent montly salary:
        agentSaldo += agentSaldo;
        //Deduct montly expenses;
        agentSaldo -= montlyExpenses;
    }

    public int GetSaldoEstimation()
    {
        //If saldo is below 10 000
        if(agentSaldo <= 10000)
        {
            return RoundToThousand(agentSaldo);
        }
        else
        {
            return RoundToTenThousand(agentSaldo);
        }
    }

    public int GetExpensesEstimation()
    {
        return montlyExpenses;
    }

    private int RoundToThousand(int i)
    {
        float number = i / 1000;
        number = Mathf.Round(number);
        number = number * 1000;

        i = (int)number;
        return i;
    }

    private int RoundToTenThousand(int i)
    {
        float number = i / 10000;
        number = Mathf.Round(number);
        number = number * 10000;

        i = (int)number;
        return i;
    }
}
