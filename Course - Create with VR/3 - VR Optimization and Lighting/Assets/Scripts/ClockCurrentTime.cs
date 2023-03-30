using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockCurrentTime : MonoBehaviour
{
    public GameObject HourHand;
    public GameObject MinuteHand;
    public GameObject SecondHand;

    private Vector3 defaultHourRotation;
    private Vector3 defaultMinuteRotation;
    private Vector3 defaultSecondRotation;

    // Start is called before the first frame update
    void Start()
    {
        defaultHourRotation = UnityEditor.TransformUtils.GetInspectorRotation(HourHand.transform);
        defaultMinuteRotation = UnityEditor.TransformUtils.GetInspectorRotation(MinuteHand.transform);
        defaultSecondRotation = UnityEditor.TransformUtils.GetInspectorRotation(SecondHand.transform);
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;

        float seconds = currentTime.Second;
        float minutes = currentTime.Minute + (seconds / 60);
        float hours = currentTime.Hour + (minutes / 60);

        SecondHand.transform.rotation = Quaternion.Euler(defaultHourRotation + new Vector3(seconds * (360 / 60), 0, 0));
        MinuteHand.transform.rotation = Quaternion.Euler(defaultMinuteRotation + new Vector3(minutes * (360 / 60), 0, 0));
        HourHand.transform.rotation = Quaternion.Euler(defaultSecondRotation + new Vector3(hours * (360 / 12), 0, 0));
    }
}
