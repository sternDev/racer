using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10f * Time.deltaTime);
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
        }
    }
}
