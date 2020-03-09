using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetector : MonoBehaviour
{
    float knockback = -10f;
    Quaternion defRotation;
    Vector3 point;
    PlayerControl playerC; 
    Rigidbody rB;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        playerC = gameObject.GetComponent<PlayerControl>();
        rB = gameObject.GetComponent<Rigidbody>();
        timer = GameObject.Find("TimerText").GetComponent<Timer>();
        defRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {

        //---------------------------------------------Hits Tree
        if(collision.gameObject.CompareTag("Tree"))
        { 
            Debug.Log($"{this} hit a Tree!");
            playerC.enabled = false;

            Vector3 Direction = collision.transform.position - transform.position;

            rB.AddForce(Direction.normalized * knockback, ForceMode.VelocityChange);
            transform.localRotation = defRotation;

            StartCoroutine(KnockbackTimer());
        }
        else if(collision.gameObject.CompareTag("Ground"))//----Touches Ground
        {
            playerC.hasJumped = false;
        }


        //------------------------------------------------Reaches Finish
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Finished!");
            timer.enabled = false;
            playerC.enabled = false;
        }

    }

    IEnumerator KnockbackTimer()
    {
        Debug.Log("Player Stunned " + Time.time);
        playerC.speed = 15;
        yield return new WaitForSeconds(3);
        playerC.enabled = true;

        Debug.Log("Player Unstunned " + Time.time);
    }
}
