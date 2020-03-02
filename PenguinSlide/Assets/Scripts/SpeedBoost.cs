using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    float rotateSpeed;
    PlayerControl playerC;

    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        rotateSpeed = 25 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("POWERUP OBTAINED!!");
            Destroy(gameObject);
            StartCoroutine(BoostTimer());
        }

    }


    IEnumerator BoostTimer()
    {
        playerC.speed += 5;
        yield return new WaitForSeconds(5);
        playerC.speed = 15;
    }
}