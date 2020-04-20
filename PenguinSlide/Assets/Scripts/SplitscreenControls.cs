using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitscreenControls : MonoBehaviour
{
//Control fields---------------------------

    float rotationSpeed = 50;
    public float speed;
    float jumpForce = 30;
    public bool hasJumped = false;
    Rigidbody rB;
    Vector3 eulerRotate;
    Vector3 rot;
    int rotLeftLimit = 250;
    int rotRightLimit = 110;
    float hInput;

//Collision fields-------------------------

    bool IsInvulnerable;
    bool isOnGround;
    float knockback = -15f;
    public AudioSource audioS;
    public AudioSource audioS2;
    Quaternion defRotation;
    Collider playerCollider;
    MeshRenderer playerMesh;

    void Start()
    {
        rB = gameObject.GetComponent<Rigidbody>();
        rot.Set(95, 0, 0);//sets def rotation
        transform.localRotation = Quaternion.Euler(rot);//rotates to default
        defRotation = transform.localRotation;
        playerCollider = GetComponent<Collider>();
        playerMesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(this.name == "Player 1")
        {
            rot = transform.localRotation.eulerAngles; //gets player rotation
            hInput = Input.GetAxis("P1") * rotationSpeed; //sets input
            movement();

            if (Input.GetKeyDown(KeyCode.W) && hasJumped == false)
            {
                audioS.Stop();
                jumpForce += Time.deltaTime;
                hasJumped = true;
                rB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        else if(this.name == "Player 2")
        {
            rot = transform.localRotation.eulerAngles; //gets player rotation
            hInput = Input.GetAxis("P2") * rotationSpeed; //sets input
            movement();

            if (Input.GetKeyDown(KeyCode.UpArrow) && hasJumped == false)
            {
                audioS.Stop();
                jumpForce += Time.deltaTime;
                hasJumped = true;
                rB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

    }
//Collision------------------------------------------------------
    private void OnCollisionEnter(Collision collision)
    {

        //---------------------------------------------Hits Tree
        if (collision.gameObject.CompareTag("Tree"))
        {
            if (IsInvulnerable == false)
            {
                Debug.Log($"{this} hit a Tree!");
                audioS2.Stop();//stops audio
                audioS.Stop();//stops audio
                enabled = false;//stops movement

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
        if(collision.gameObject.CompareTag("Finish"))
        {
            audioS.Stop();
            audioS2.Stop();
        }
        else if (collision.gameObject.CompareTag("Ground"))//----Touches Ground
        {
            isOnGround = true;
            hasJumped = false;
            if (enabled == true && isOnGround)
            {
                audioS.Play();
            }
            if (enabled == false)
            {
                audioS.Stop();
            }
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
        speed = 20;
        yield return new WaitForSeconds(3);
        enabled = true;
        if (isOnGround)
        {
            audioS.Play();
        }
        else
        {
            audioS.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            //pUpSound.Play();
            //Debug.Log("POWERUP OBTAINED!!");
            StartCoroutine(BoostTimer(5f));
            Destroy(other.gameObject);
        }

    }

    IEnumerator BoostTimer(float waitTime)
    {
        speed += 5;
        //Debug.Log($"boost! {playerC.speed}");
        yield return new WaitForSeconds(waitTime);
        // Debug.Log($"slow! {playerC.speed}");
        if (speed > 20)
        {
            speed -= 5;
        }
        else
        {
            speed = 20;
        }
    }

//Movement------------------------------------------------------
    private void movement()
    {
        Vector3 fSpeed = (speed * Vector3.up * Time.deltaTime); //sets speed and direction
        hInput *= Time.deltaTime; //input * time.deltatime
        eulerRotate.z = hInput * 2; //rotation = input
        //Debug.Log($"{rot}");

        //transform.Translate(hInput, 0, 0);
        //if player rotation reaches those angles move
        transform.Rotate(-eulerRotate, Space.Self);
        if (rot.z > rotLeftLimit) //limits player rotation left
        {
            rot.Set(85, rot.y, 249);//for some reason setting to rot.z to 220 disables right input
            transform.localRotation = Quaternion.Euler(rot);
        }
        else if (rot.z < rotRightLimit) //limits player rotation right
        {
            rot.Set(85, rot.y, 111);
            transform.localRotation = Quaternion.Euler(rot);
        }

        transform.Translate(fSpeed, Space.Self);//moves player forward
    }

}
