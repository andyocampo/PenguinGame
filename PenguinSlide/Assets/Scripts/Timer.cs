using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Text timer; //contains timer
    private float startTime, seconds, minutes;
    Scene scene;
    bool timerStarted;
    public float i;//seconds left in countdown timer
    public float f = 1;//seconds after timer reaches 0;

    void Start()
    {
        timer = GetComponent<Text>(); //gets text component
        startTime = Time.time;
        timerStarted = false;
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (scene.buildIndex == 1 && !timerStarted)
        {
            StartCoroutine(CountdownTimer());
            timerStarted = true;
        }
        else if (scene.buildIndex == 2)
        {
            CountupTimer();
        }
    }

    void CountupTimer()
    {
        float t = Time.time - startTime;

        minutes = (int)(t / 60f);
        seconds = (int)(t % 60f);
        timer.text = $"Time: {minutes.ToString("00")}:{seconds.ToString("00")}";
    }

    IEnumerator CountdownTimer()
    {
        for (i = 45; i > 0;)
        {
            timer.text = $"Time: 00:{i.ToString("00")}";
            yield return new WaitForSeconds(1);
            i--;
        }
        while (i <= 0)
        {
            timer.text = $"Time: +00:{f.ToString("00")}";
            yield return new WaitForSeconds(1);
            f++;
        }

    }

}
