using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisonDetector : MonoBehaviour
{
    bool IsInvulnerable;
    float knockback = -15f;
    bool isOnGround;
    Quaternion defRotation;
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
            if (IsInvulnerable == false)
            {
                Debug.Log($"{this} hit a Tree!");
                playerC.audioS2.Stop();//stops audio
                playerC.audioS.Stop();//stops audio
                playerC.enabled = false;//stops movement
                isOnGround = false;
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
            isOnGround = true;
            playerC.hasJumped = false;
            if(playerC.enabled == true && isOnGround)
            {
                playerC.audioS.Play();
            }
            if(playerC.enabled == false)
            {
                playerC.audioS.Stop();
            }
            
        }


        //------------------------------------------------Reaches Finish
        if (collision.gameObject.CompareTag("Finish"))
        {
            playerC.speed = 1;
            playerC.audioS.Stop();
            playerC.audioS2.Stop();
        }
    }

    IEnumerator Invulnerablity()
    {
        float invulnerablityTime = 20;
        IsInvulnerable = true;
        for (int i = 0; i < invulnerablityTime; i++)
        {
            playerMesh.enabled = false;
            yield return new WaitForSeconds(.25f);
            playerMesh.enabled = true;
            yield return new WaitForSeconds(.25f);
            invulnerablityTime--;
        }
        IsInvulnerable = false;

    }

    IEnumerator KnockbackTimer() //when player gets knocked back, short timer freezes them
    {
        //Debug.Log("Player Stunned " + Time.time);
        playerC.speed = 20;
        yield return new WaitForSeconds(3);
        playerC.enabled = true;
        if (isOnGround)
        {
            playerC.audioS.Play();
        }
        else
        {
            playerC.audioS.Stop();
        }
        //Debug.Log("Player Unstunned " + Time.time);
    }
}
