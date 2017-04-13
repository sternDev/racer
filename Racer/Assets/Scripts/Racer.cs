using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class Racer : MonoBehaviour {

    public GameObject street;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 temp = new Vector3(-0.1f, 0, 0);
            this.transform.position += temp;
        } else if(Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 temp = new Vector3(0.1f, 0, 0);
            this.transform.position += temp;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            SceneManager.LoadScene("StartScreen");
        }
        if (collision.gameObject.tag == "Money")
        {
            Destroy(collision.gameObject);
        }
    }


    /*  private bool CheckCollide()
      {
          Vector3 racerPosition = this.transform.position;
          Vector3 streetPosition = street.transform.position;
          //Vector3 streetPosition = street.transform.position;

          if (racerPosition.x > streetPosition.x)
          {

          }
      }*/
}
