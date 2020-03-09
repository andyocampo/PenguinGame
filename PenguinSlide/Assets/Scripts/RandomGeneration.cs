using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    [SerializeField]GameObject[] Obstacles;
    [SerializeField]GameObject[] PowerUps;
    [SerializeField]int obstaclesAmount = 5;
    [SerializeField]int powersAmount = 10;

    Vector3 randomPosition;

    float randomX;
    float randomY;
    float randomZ;
    Vector3 boundMax, boundMin;
    int i;

    void Start()
    {
        i = 0;
    }

    void Update()
    {
        GenerateRandomPos();
        if(i < obstaclesAmount)
        {
            i++;
            GameObject obj = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)]);
            obj.transform.position = randomPosition;
        }

        if (i < powersAmount)
        {
            i++;
            GameObject pUP = Instantiate(PowerUps[Random.Range(0, PowerUps.Length)]);
            pUP.transform.position = randomPosition;
        }
    }

    void GenerateRandomPos()
    {
        GameObject plane = this.gameObject;
        Renderer planeRend = plane.GetComponent<Renderer>();
        boundMax = planeRend.bounds.max;
        boundMin = planeRend.bounds.center;
        randomX = Random.Range(boundMin.x, boundMax.x);
        randomY = Random.Range(boundMin.y, boundMax.y);
        randomZ = Random.Range(boundMin.z,boundMax.z);
        randomPosition = new Vector3(randomX, randomY, randomZ);


    }
}
