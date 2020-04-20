using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]float rotateSpeed;

    private void Start()
    {
        rotateSpeed = -25 * Time.deltaTime;
    }

    // spins power up
    void Update()
    {
        if(Time.timeScale == 1)
        {
            transform.Rotate(0, rotateSpeed, 0, Space.Self);
        }
        else
        {
            transform.Rotate(0, 0, 0, Space.Self);
        }
    }
}
