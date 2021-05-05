using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Stopwatch : MonoBehaviour
{
    public float timeStart = 0;
    public Text timeText;
    public bool isPaused = false;

    void Start()
    {
        timeText.text = timeStart.ToString();
    }

    void FixedUpdate()
    {
        if (!isPaused)
        {
            timeStart += Time.deltaTime;
            timeText.text = Math.Round(timeStart, 2).ToString();
        }
    }

    public void resetStopwatch()
    {
        timeStart = 0;
    }

    public void setPause(bool ispaused)
    {
        isPaused = ispaused;
    }
}
