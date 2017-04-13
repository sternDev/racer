using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

    GameObject[] streetMarkers;
    public GameObject positionStreetEnding;
    public GameObject positionStreetStart;


    float streetStart;
    float streetEnd;

    float speed = 20f;

    // Use this for initialization
    void Start () {

        //  positionStreetStart = streetPosition.z;
        streetStart = positionStreetStart.transform.position.z;
        streetEnd = positionStreetEnding.transform.position.z;

        startStreet();
    }

    // Update is called once per frame
    void Update()
    {
        if (streetMarkers.Length > 0)
        {
            foreach (GameObject streetMark in streetMarkers)
            {
                Vector3 temp = new Vector3(0, 0, -speed*Time.deltaTime);
                streetMark.transform.position += temp;
                if(streetMark.transform.position.z <= streetStart)
                {
                    temp = new Vector3(streetMark.transform.position.x, streetMark.transform.position.y, streetEnd);
                    streetMark.transform.position = temp;
                }
            }
        }
    }

    public void startStreet()
    {
        Debug.Log("Start Marker Script");

        streetMarkers = GameObject.FindGameObjectsWithTag("StreetMark");
    }
}
