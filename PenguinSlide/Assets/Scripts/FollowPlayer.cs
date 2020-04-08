using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 offset;
    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 2, -2);
        rotation = new Vector3(20, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.eulerAngles = rotation;
    }
}