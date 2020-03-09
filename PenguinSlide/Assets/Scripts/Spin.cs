using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    float rotateSpeed;

    private void Start()
    {
        rotateSpeed = -25 * Time.deltaTime;
    }

    // spins power up
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.Self);
    }
}
