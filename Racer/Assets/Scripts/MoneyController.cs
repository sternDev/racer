using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour {
    private Transform startPosition;
    // Use this for initialization
    void Start () {
        startPosition = GameObject.Find("StreetStart").gameObject.GetComponent<Transform>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 30f * Time.deltaTime);
        transform.position = pos;
        RemoveMoney();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
        }
    }


    float GroundDistance;
    void RemoveMoney()
    {
        if(gameObject.transform.position.z <= startPosition.position.z) {
            Destroy(gameObject);
        }

    }
}
