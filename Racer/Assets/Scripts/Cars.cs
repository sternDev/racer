using UnityEngine;
using System.Collections;

public class Cars : MonoBehaviour
{

    public GameObject Car;
    public GameObject positionStreetStart;
    public GameObject positionStreetEnding;
    public GameObject positionStreetLeft;
    public GameObject positionStreetRight;
    public GameObject timer;

    public float carsSpeed = 0.3f;
    float streetStart;
    float streetEnd;
    float streetLeft;
    float streetRight;


    // Use this for initialization
    void Start()
    {
        streetStart = positionStreetStart.transform.position.z;
        streetEnd = positionStreetEnding.transform.position.z;

        streetLeft = positionStreetLeft.transform.position.x;
        streetRight = positionStreetRight.transform.position.x;

        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        GameObject[] Cars = GameObject.FindGameObjectsWithTag("Car");

        if (Cars.Length < timer.GetComponent<Timer>().GetCurrentMinute()+1)
        {
            Vector3 temp = new Vector3(Random.Range(streetLeft, streetRight), 1, streetEnd);
            Instantiate(Car).gameObject.transform.position = temp;

        }
        StartCoroutine(SpawnCars());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Cars = GameObject.FindGameObjectsWithTag("Car");

        foreach (GameObject CarObject in Cars)
        {
            Vector3 temp = new Vector3(0, 0, -carsSpeed);
            CarObject.transform.position += temp;

            if (CarObject.transform.position.z <= streetStart)
            {
                Destroy(CarObject);
            }
        }
    }

}
