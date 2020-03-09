using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float rotationSpeed = 50;
    public float speed = 3;
    float jumpForce = 20;
    public bool hasJumped = false;
    Rigidbody rB;
    Vector3 eulerRotate;
    Vector3 rot;

    void Start()
    {
        rB = gameObject.GetComponent<Rigidbody>();
        rot.Set(110, 0, 0);//sets def rotation
        transform.localRotation = Quaternion.Euler(rot);//rotates to default
        //Debug.Log($"{rot}");
    }

    void Update()
    {
        rot = transform.localRotation.eulerAngles; //gets player rotation
        float hInput = Input.GetAxis("Horizontal") * rotationSpeed; //sets input
        Vector3 fSpeed = (speed * Vector3.up * Time.deltaTime); //sets speed and direction
        hInput *= Time.deltaTime; //input * time.deltatime
        eulerRotate.z = hInput; //rotation = input
        //Debug.Log($"{rot}");

        //transform.Translate(hInput, 0, 0);
        if (rot.z <= 220 || rot.z >= 140) //if player rotation reaches those angles move
        {
            transform.Rotate(-eulerRotate, Space.Self);
        }
        if (rot.z > 220) //limits player rotation left
        {
            rot.Set(70, 180, 220);
            transform.localRotation = Quaternion.Euler(rot);
        }
        else if(rot.z < 140) ////limits player rotation right
        {
            rot.Set(70, 180, 140);
            transform.localRotation = Quaternion.Euler(rot);
        }

        transform.Translate(fSpeed, Space.Self);//moves player forward

        Jump();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && hasJumped == false)
        {
            jumpForce += Time.deltaTime;
            hasJumped = true;
            rB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
