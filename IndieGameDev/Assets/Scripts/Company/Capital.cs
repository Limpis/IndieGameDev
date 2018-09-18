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

    public void AddMoney(int money)
    {
        currentMoney += money;
        UpdateCapitalText();
    }

    private void Start()
    {
        UpdateCapitalText();
    }

    private void UpdateCapitalText()
    {
        capitalText.text = currentMoney.ToString() + " €";
    }
}
