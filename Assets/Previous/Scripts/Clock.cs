using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        DateTime currentTime = DateTime.Now;

        // seconds 
        float secs = currentTime.Second;
        float secsRotation = (secs / 60f) * 360f;
        secondHand.transform.rotation = Quaternion.Euler(secsRotation, 0, 0);

        // minutes
        float mins = currentTime.Minute;
        float minsRotation = (mins / 60f) * 360f;
        minuteHand.transform.rotation = Quaternion.Euler(minsRotation, 0, 0);

        // hours
        float hrs = currentTime.Hour;
        float hrsRotation = (hrs / 12f) * 360f;
        hourHand.transform.rotation = Quaternion.Euler(hrsRotation, 0, 0);
    }
}
