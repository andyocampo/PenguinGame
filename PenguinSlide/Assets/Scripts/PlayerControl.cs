using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float rotationSpeed = 5;
    public float speed = 3;
    float jumpForce = 10;
    Rigidbody rB;

    // Start is called before the first frame update
    void Start()
    {
        rB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal") * rotationSpeed;
        Vector3 fSpeed = (speed * Vector3.up * Time.deltaTime);
        hInput *= Time.deltaTime;
        

        transform.Translate(hInput, 0, 0);
        transform.Translate(fSpeed, Space.Self);
        Jump();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpForce += Time.deltaTime;

            rB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
