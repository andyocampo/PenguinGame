using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerWin : MonoBehaviour
{
    [SerializeField] GameObject p1Win;
    [SerializeField] GameObject p2Win;
    [SerializeField] GameObject WinMenu;
    [SerializeField] GameObject winText;
    Text finishText;
    int counter;
    bool GameWon;
    int player;

    void Start()
    {
        p1Win.SetActive(false);
        p2Win.SetActive(false);
        finishText = winText.GetComponent<Text>();
        GameWon = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        counter++;
        if (collision.gameObject.CompareTag("Player 1") && GameWon == false)
        {
            player = 1;
            StartCoroutine(SlowDown());
            p1Win.SetActive(true);
            GameWon = true;
        }
        if (collision.gameObject.CompareTag("Player 2") && GameWon == false)
        {
            player = 2;
            StartCoroutine(SlowDown());
            p2Win.SetActive(true);
            GameWon = true; 
        }
        if (counter == 2 && GameWon == true)
        {
            p1Win.SetActive(false);
            p2Win.SetActive(false);
            Time.timeScale = 0;
            finishText.text = $"PLAYER {player} WINS!";
            WinMenu.SetActive(true);
        }
    }

    IEnumerator SlowDown()
    {
        GameObject.Find($"Player {player}").GetComponent<SplitscreenControls>().speed = 5;
        yield return new WaitForSeconds(1);
        GameObject.Find($"Player {player}").GetComponent<SplitscreenControls>().enabled = false;
    }
}
