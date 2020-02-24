using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    Vector3 add;

    // Start is called before the first frame update
    void Start()
    {
        add = new Vector3(0,0.01f,-0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += add;
    }
}
