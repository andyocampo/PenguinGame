using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetector : MonoBehaviour
{
    bool invulnerable;
    float knockback = -10f;
    Quaternion defRotation;
    Vector3 point;
    PlayerControl playerC; 
    Rigidbody rB;
    Timer timer;
    Collider playerCollider;
    MeshRenderer playerMesh;

    // Start is called before the first frame update
    void Start()
    {
        playerC = gameObject.GetComponent<PlayerControl>();
        rB = gameObject.GetComponent<Rigidbody>();
        timer = GameObject.Find("TimerText").GetComponent<Timer>();
        defRotation = transform.localRotation;
        playerCollider = GetComponent<Collider>();
        playerMesh = GetComponent<MeshRenderer>();
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
            if (invulnerable == false)
            {
                Debug.Log($"{this} hit a Tree!");
                playerC.enabled = false;//stops movement

                Vector3 Direction = collision.transform.position - transform.position;

                rB.AddForce(Direction.normalized * knockback, ForceMode.VelocityChange);

                transform.localRotation = defRotation;//sets default rotation
                StartCoroutine(Invulnerablity());
                StartCoroutine(KnockbackTimer());
            }
            else
            {
                Physics.IgnoreCollision(collision.collider, playerCollider);
            }

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

    IEnumerator Invulnerablity()
    {
        float invulnerablityTime = 20;
        invulnerable = true;
        for (int i = 0; i < invulnerablityTime; i++)
        {
            playerMesh.enabled = false;
            yield return new WaitForSeconds(.25f);
            playerMesh.enabled = true;
            yield return new WaitForSeconds(.25f);
            invulnerablityTime--;
        }
        invulnerable = false; 
    }

    IEnumerator KnockbackTimer() //when player gets knocked back, short timer freezes them
    {
        Debug.Log("Player Stunned " + Time.time);
        playerC.speed = 15;
        yield return new WaitForSeconds(3);
        playerC.enabled = true;

        Debug.Log("Player Unstunned " + Time.time);
    }
}
