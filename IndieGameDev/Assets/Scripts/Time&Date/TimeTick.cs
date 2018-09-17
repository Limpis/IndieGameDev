using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTick : MonoBehaviour {

    [SerializeField]
    [Tooltip("Seconds per in-game week.")]
    private int tickSpeed;

    private Calendar calendar;
    private WaitForSeconds wait;

    private void Start()
    {
        calendar = GetComponent<Calendar>();
        wait = new WaitForSeconds(tickSpeed);

        StartCoroutine(TickCount());
    }

    IEnumerator TickCount()
    {
        while (true)
        {
            yield return wait;
            calendar.WeekTick();
        }
    }
}
