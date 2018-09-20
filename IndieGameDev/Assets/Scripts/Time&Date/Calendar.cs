using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour {

    [SerializeField]
    private int startYear = 2018, startWeek = 1;
    [SerializeField]
    private Text calendarText;

    private int currentYear, currentWeek;
    private int weekInMonth = 1;

    private CompanySalaries salaries;

    public void WeekTick()
    {
        MonthTick();

        currentWeek += 1;
        if(currentWeek > 52)
        {
            currentWeek = 1;
            currentYear++;
        }

        UpdateCalendarText();
    }

    private void Start()
    {
        currentYear = startYear;
        currentWeek = startWeek;

        UpdateCalendarText();
        salaries = GameObject.FindGameObjectWithTag("Capital").GetComponent<CompanySalaries>();
    }

    private void UpdateCalendarText()
    {
        calendarText.text = currentYear.ToString() + " W" + currentWeek.ToString();
    }

    private void MonthTick()
    {
        weekInMonth++;

        if (weekInMonth > 4)
        {
            salaries.PaySalaries();
            weekInMonth = 1;
        }
    }
}
