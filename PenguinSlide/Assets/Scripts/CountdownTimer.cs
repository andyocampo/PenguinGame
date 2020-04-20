using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    //Counts 3...2...1...GO
    Text Count;
    Scene scene;
    [SerializeField] GameObject Player;
    [SerializeField] AudioSource Sound;
    [SerializeField] AudioClip raceMusic;
    [SerializeField] AudioClip countDownSound;
    [SerializeField] AudioClip goSound;
    bool started;

    void Start()
    {
        Count = GetComponent<Text>();
        started = false;
        Player.GetComponent<Pause>().enabled = false;
        scene = SceneManager.GetActiveScene();
        Time.timeScale = 0;
    }

    void LateUpdate()
    {
        if (Time.timeScale == 0 && !started)
        {
            StartCoroutine(CountDown());
        }
        else
        {
        }

    }

    IEnumerator CountDown()
    {
        if(scene.buildIndex == 1)
        {
            started = true;
            Count.fontSize = 33;
            Count.text = "Avoid obstacles and reach the bottom before time runs out";
            yield return new WaitForSecondsRealtime(3f);
            Count.fontSize = 55;
            Count.text = "3";
            Sound.Play();
            yield return new WaitForSecondsRealtime(1f);
            Count.text = "2";
            Sound.Play();
            yield return new WaitForSecondsRealtime(1f);
            Count.text = "1";
            Sound.Play();
            yield return new WaitForSecondsRealtime(1f);
            Sound.clip = goSound;
            Sound.Play();
            Time.timeScale = 1;
            Count.text = "GO!";
            Sound.clip = raceMusic;
            Sound.volume = 0.1f;
            Sound.Play();
            Sound.loop = true;
            yield return new WaitForSecondsRealtime(2f);
            Count.text = "";
            Player.GetComponent<Pause>().enabled = true;
        }
        else if (scene.buildIndex == 2)
        {
            started = true;
            Count.fontSize = 33;
            Count.text = "Reach the bottom first to win!";
            yield return new WaitForSecondsRealtime(3f);
            Count.fontSize = 55;
            Count.text = "3";
            Sound.Play();
            yield return new WaitForSecondsRealtime(1f);
            Count.text = "2";
            Sound.Play();
            yield return new WaitForSecondsRealtime(1f);
            Count.text = "1";
            Sound.Play();
            yield return new WaitForSecondsRealtime(1f);
            Sound.clip = goSound;
            Sound.Play();
            Time.timeScale = 1;
            Count.text = "GO!";
            Sound.clip = raceMusic;
            Sound.volume = 0.1f;
            Sound.Play();
            Sound.loop = true;
            yield return new WaitForSecondsRealtime(2f);
            Count.text = "";
            Player.GetComponent<Pause>().enabled = true;
        }

    }
}
