using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetector : MonoBehaviour
{
    PlayerControl playerC;
    // Start is called before the first frame update
    void Start()
    {
        playerC = gameObject.GetComponent<PlayerControl>();
        
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

            Vector3 knockback = new Vector3(0, -200, -100);
            transform.Translate(knockback * Time.deltaTime, Space.Self);

            StartCoroutine(KnockbackTimer());

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
