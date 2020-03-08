using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float rotationSpeed = 5;
    public float speed = 3;
    float jumpForce = 15;
    float rotateLimit = 25;
    public bool hasJumped = false;
    Rigidbody rB;
    Vector3 eulerRotate;

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
        eulerRotate = new Vector3(0, 0, hInput);

        //transform.Translate(hInput, 0, 0);
        if (transform.rotation.z <= rotateLimit || transform.rotation.z >= -rotateLimit)
        {
            transform.Rotate(-eulerRotate.normalized * 50 * Time.deltaTime, Space.Self);
        }
        else
        {
            Debug.Log("LIMIT REACHED");
        }
        transform.Translate(fSpeed, Space.Self);
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
