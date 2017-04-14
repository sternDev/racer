using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class Racer : MonoBehaviour {

    public GameObject street;
    private GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("Game").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 temp = new Vector3(-0.1f, 0, 0);
            this.transform.position += temp;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
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
            gameController.CountMoney();
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
