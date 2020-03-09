using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timer; //contains timer
    public float seconds, minutes;

    void Start()
    {
        timer = GetComponent<Text>(); //gets text component
    }

    void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        timer.text = $"Time: {minutes.ToString("00")}:{seconds.ToString("00")}"; 
    }
}
