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

    // Start is called before the first frame update
    void Start()
    {
        playerC = gameObject.GetComponent<PlayerControl>();
        rB = gameObject.GetComponent<Rigidbody>();
        defRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Tree"))
        { 
            Debug.Log($"{this} hit a Tree!");
            playerC.enabled = false;

            Vector3 Direction = collision.transform.position - transform.position;

            rB.AddForce(Direction.normalized * knockback, ForceMode.VelocityChange);
            transform.rotation = defRotation;

            StartCoroutine(KnockbackTimer());
        }
        else if(collision.gameObject.CompareTag("Ground"))
        {
            playerC.hasJumped = false;
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
