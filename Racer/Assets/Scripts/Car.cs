using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Car : MonoBehaviour
{

    public float carSpeed = 0.3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetCarSpeed()
    {
        return carSpeed;
    }

    public void drive(float streetStart)
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        System.Array.Reverse(cars);

        float test = 0;
        foreach (GameObject carObject in cars)
        {
            test = 0;
            if (!carObject.Equals(this.gameObject))
            {
                Debug.Log(Mathf.Abs((gameObject.transform.position - carObject.transform.position).y));
                // if (Vector3.Distance(gameObject.transform.position, carObject.transform.position) <= 50)
                if (Mathf.Abs((gameObject.transform.position - carObject.transform.position).y) <= 0.1f)
                {
                  // test = 10 * Time.deltaTime;
                }
            }
        }
        Vector3 temp = new Vector3(test, 0, -GetCarSpeed());
        if(temp.x > -13 && temp.x < 13)
        {

            transform.position += temp;
        }

        if (transform.position.z <= streetStart)
        {
            Destroy(gameObject);
        }
    }
}
