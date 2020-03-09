using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timer; //contains timer
    public float startTime, seconds, minutes;

    void Start()
    {
        timer = GetComponent<Text>(); //gets text component
        startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;

        minutes = (int)(t / 60f);
        seconds = (int)(t % 60f);
        timer.text = $"Time: {minutes.ToString("00")}:{seconds.ToString("00")}"; 
    }
}
