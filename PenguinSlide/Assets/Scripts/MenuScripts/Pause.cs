using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    bool isPaused;

    void Start()
    {
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseInput();
    }

    private void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
