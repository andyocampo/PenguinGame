using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    Timer timer;
    [SerializeField] GameObject WinMenu;
    [SerializeField] GameObject winText;
    Text finishText;
    bool GameDone;

    void Start()
    {
        timer = GameObject.Find("TimerText").GetComponent<Timer>();
        finishText = winText.GetComponent<Text>();
        GameDone = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (timer.i > 0 && GameDone == false)
        {
            Time.timeScale = 0.01f;
            finishText.text = "YOU WIN!";
            WinMenu.SetActive(true);
            timer.enabled = false;
            GameDone = true;
        }
        else if (timer.i <= 0 && GameDone == false)
        {
            Time.timeScale = 0.01f;
            finishText.fontSize = 30;
            if(timer.f > 1)
            {
                finishText.text = $"YOU FAILED!\n{timer.f} seconds too late!";
            }
            else
            {
                finishText.text = $"YOU FAILED!\n{timer.f} second too late!";
            }
            WinMenu.SetActive(true);
            timer.enabled = false;
            GameDone = true;
        }
    }
}
