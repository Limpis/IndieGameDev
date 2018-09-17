using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour {

    [SerializeField]
    private int startYear, startWeek;
    [SerializeField]
    private Text calendarText;

    private int currentYear, currentWeek;

    public void WeekTick()
    {
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
    }

    private void UpdateCalendarText()
    {
        calendarText.text = currentYear.ToString() + " W" + currentWeek.ToString();
    }
}
