using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTracker : MonoBehaviour
{
    PlayerControl playerC;
    AudioSource pUpSound;

    // Start is called before the first frame update
    void Awake()
    {
        playerC = gameObject.GetComponent<PlayerControl>();
        pUpSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            pUpSound.Play();
            Debug.Log("POWERUP OBTAINED!!");
            StartCoroutine(BoostTimer(5f));
            Destroy(other.gameObject);
        }

    }

    IEnumerator BoostTimer(float waitTime)
    {
        playerC.speed += 5;
        Debug.Log($"boost! {playerC.speed}");
        yield return new WaitForSeconds(waitTime);
        Debug.Log($"slow! {playerC.speed}");
        if(playerC.speed > 20)
        {
            playerC.speed -= 5;
        }
        else
        {
            playerC.speed = 20;
        }
    }
}
