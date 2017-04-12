using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {



    public float carSpeed = 0.3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public float GetCarSpeed()
    {
        return this.carSpeed;
    }
}
