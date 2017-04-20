using UnityEngine;
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

    private int[] streetPositions = new int[3];


    // Use this for initialization
    void Start()
    {

        streetPositions[0] = -8;
        streetPositions[1] = 8;
        streetPositions[2] = 0;
        gameController = GameObject.Find("Game").GetComponent<GameController>();
        streetStart = positionStreetStart.transform.position.z;
        streetEnd = positionStreetEnding.transform.position.z;

        streetLeft = positionStreetLeft.transform.position.x;
        streetRight = positionStreetRight.transform.position.x;

        StartCoroutine(SpawnCars());
        StartCoroutine(SpawnMoney());

        // it is the first car!
        CreateCar(-8, Random.Range(0, 2));
    }

    IEnumerator SpawnCars()
    {
        yield return new WaitForSeconds(Random.Range(2f, 4f));

        switch (gameController.GetLevel())
        {
            case 1:
                // create only cars at the right side of the street.
                //CreateCar(Random.Range(-13, -5), Random.Range(0, 2));
                CreateCar(streetPositions[0], Random.Range(0, 2));
                break;

            case 2:
                // Create cars on both sides
                CreateCar(streetPositions[(int)Random.Range(0,2)], Random.Range(0, 2));
                break;

            case 3:
                // create two cars :)
                CreateCar(streetPositions[0], Random.Range(0, 2));
                CreateCar(streetPositions[1], Random.Range(0, 2));
                break;

            case 4:
                CreateCar(streetPositions[Random.Range(0,2)], Random.Range(0, 2));
                CreateCar(streetPositions[Random.Range(0, 2)], Random.Range(0, 2));
                break;

            default:
                // do nothing at this moment.
                CreateCar(streetPositions[Random.Range(0, 2)], Random.Range(0, 2));
                CreateCar(streetPositions[Random.Range(0, 2)], Random.Range(0, 2));
                break;
        }

        StartCoroutine(SpawnCars());
    }

    private void CreateCar(float positionX, int carNumber)
    {
        Vector3 temp;
        temp = new Vector3(positionX, 1, streetEnd);
        Instantiate(CarPool[carNumber], temp, Quaternion.identity);
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

        for (int i = 0; i <= 10; i++)
        {
            Instantiate(moneyObject, new Vector3(positionX, 1, (streetEnd - 5 * i)), Quaternion.identity);
        }
        StartCoroutine(SpawnMoney());
    }

}
