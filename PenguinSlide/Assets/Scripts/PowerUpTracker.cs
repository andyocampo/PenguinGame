using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUpTracker : MonoBehaviour
{
    PlayerControl playerC;
    public GameObject SpeedLines;
    Animator speedLineAnim;
    SplitscreenControls ssc;
    Scene scene;
    int sLIncrease = 0;

    // Start is called before the first frame update
    void Awake()
    {
        playerC = gameObject.GetComponent<PlayerControl>();
        speedLineAnim = SpeedLines.GetComponent<Animator>();
        ssc = GetComponent<SplitscreenControls>();
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            sLIncrease = 1;
            SpeedLineCounter();
            Debug.Log("POWERUP OBTAINED!!");

            StartCoroutine(BoostTimer(5f));
            Destroy(other.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            speedLineAnim.speed = 1;
            SpeedLines.SetActive(false);
        }
    }

    void SpeedLineCounter()
    {

        if(sLIncrease == 1)
        {
            speedLineAnim.speed += .1f;
            SpeedLines.SetActive(true);
        }
        else
        {
            speedLineAnim.speed = 0;
            SpeedLines.SetActive(false);
        }

    }


    IEnumerator BoostTimer(float waitTime)
    {
        if (scene.buildIndex == 1)
        {
            playerC.speed += 5;
            playerC.audioS2.Play();
            playerC.audioS2.pitch += .2f;
            playerC.audioS.pitch += .01f;
            //Debug.Log($"boost! {playerC.speed}");
            yield return new WaitForSeconds(waitTime);
            sLIncrease = 0;
            //Debug.Log($"slow! {playerC.speed}");
            if (playerC.speed > 20)
            {
                playerC.speed -= 5;
            }
            else
            {

                playerC.speed = 20;
            }

            if (playerC.speed == 20)
            {
                playerC.audioS.pitch = 1;
                playerC.audioS2.pitch = 1;
                playerC.audioS2.Stop();
                speedLineAnim.speed = 1;
                SpeedLines.SetActive(false);
            }
        }
        else if (scene.buildIndex == 2)
        {
            ssc.speed += 5;
            ssc.audioS2.Play();
            ssc.audioS2.pitch += .2f;
            ssc.audioS.pitch += .01f;
            yield return new WaitForSeconds(waitTime);
            sLIncrease = 0;
            if (ssc.speed > 20)
            {
                ssc.speed -= 5;
            }
            else
            {
                ssc.speed = 20;
            }

            if (ssc.speed == 20)
            {
                ssc.audioS.pitch = 1;
                ssc.audioS2.pitch = 1;
                ssc.audioS2.Stop();
                speedLineAnim.speed = 1;
                SpeedLines.SetActive(false);
            }

        }
    }
}
