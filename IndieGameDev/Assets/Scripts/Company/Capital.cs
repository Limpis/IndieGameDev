using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capital : MonoBehaviour {

    //Script for managing company money.

    [SerializeField]
    private int currentMoney;

    [SerializeField]
    private Text capitalText;

    private bool redNumbers = false;

    public void AddMoney(int money)
    {
        currentMoney += money;
        UpdateCapitalText();
    }

    public void RemoveMoney(int money)
    {
        Debug.Log("Remove money called. Removing " + money + " money");
        currentMoney -= money;
        UpdateCapitalText();
    }

    private void Start()
    {
        UpdateCapitalText();
    }

    private void UpdateCapitalText()
    {
        capitalText.text = currentMoney.ToString() + " €";

        if(currentMoney < 0)
        {
            if(!redNumbers)
            {
                RedNumbers();
            }
        }
        else if(currentMoney >= 0)
        {
            if(redNumbers)
            {
                BlackNumbers();
            }
        }
    }

    private void RedNumbers()
    {
        capitalText.color = Color.red;
        redNumbers = true;
    }

    private void BlackNumbers()
    {
        capitalText.color = Color.black;
        redNumbers = false;
    }
}
