using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionTracker : MonoBehaviour
{
    float p1Pos;
    float p2Pos;
    [SerializeField] Text p1Text;
    [SerializeField] Text p2Text;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    void Update()
    {
        p1Pos = player1.transform.localPosition.z;
        p2Pos = player2.transform.localPosition.z;

        if (p1Pos > p2Pos)
        {
            p1Text.text = "First";
            p2Text.text = "Second";
        }
        if (p1Pos < p2Pos)
        {
            p1Text.text = "Second";
            p2Text.text = "First";
        }
        else if (p1Pos == p2Pos)
        {
            p1Text.text = "";
            p2Text.text = "";
        }
    }
}
