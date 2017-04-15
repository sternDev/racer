﻿using UnityEngine;
using System.Collections;

public class CarManager : MonoBehaviour
{

    public GameObject[] CarPool;
    public GameObject moneyObject;
    public GameObject positionStreetStart;
    public GameObject positionStreetEnding;
    public GameObject positionStreetLeft;
    public GameObject positionStreetRight;

    float streetStart;
    float streetEnd;
    float streetLeft;
    float streetRight;
    
    GameController gameController;


    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("Game").GetComponent<GameController>();
        streetStart = positionStreetStart.transform.position.z;
        streetEnd = positionStreetEnding.transform.position.z;

        streetLeft = positionStreetLeft.transform.position.x;
        streetRight = positionStreetRight.transform.position.x;

        StartCoroutine(SpawnCars());
        StartCoroutine(SpawnMoney());
    }

    IEnumerator SpawnCars()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        GameObject[] Cars = GameObject.FindGameObjectsWithTag("Car");

        for(int i = 0; i < gameController.GetLevel(); i++)
        {
            Vector3 temp = new Vector3(Random.Range(streetLeft + 40, streetRight - 40), 1, streetEnd);
            Instantiate(CarPool[Random.Range(0, 2)]).gameObject.transform.position = temp;
        }
           
        StartCoroutine(SpawnCars());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Cars = GameObject.FindGameObjectsWithTag("Car");

        foreach (GameObject CarObject in Cars)
        {
            CarObject.GetComponent<Car>().drive(streetStart);
        }
    }


    IEnumerator SpawnMoney()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        float positionX = Random.Range(streetLeft + 10, streetRight - 10);

        for (int i = 0; i <=10; i++)
        {
            Instantiate(moneyObject, new Vector3(positionX, 1, (streetEnd-5*i)), Quaternion.identity);
        }
        StartCoroutine(SpawnMoney());
    }

}
