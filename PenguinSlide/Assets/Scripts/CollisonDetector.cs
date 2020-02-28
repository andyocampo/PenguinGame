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

            playerC.speed = 5;
        }
    }
}
