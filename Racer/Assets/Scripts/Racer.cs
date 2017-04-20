using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class Racer : MonoBehaviour
{

    public GameObject street;
    private GameController gameController;
    public float speed = 200f;
    private bool speedBoost = false;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("Game").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = speed*Input.GetAxis("Horizontal");
        if (speedBoost)
        {
            currentSpeed *= 2;
        }
        Vector3 temp = new Vector3(currentSpeed * Time.deltaTime, 0, 0);
        if(temp.x > -13 && temp.x < 13)
        {

            this.transform.position += temp;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (gameController.GetMoney() >= 30)
            {
                speedBoost = true;
                gameController.MinimizeMoney(30);
                StartCoroutine(StopBoost());
            }
        }
    }

    IEnumerator StopBoost()
    {
        yield return new WaitForSeconds(3);
        speedBoost = false;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            gameController.AddHighscore();

            SceneManager.LoadScene("StartScreen");
        }
        if (collision.gameObject.tag == "Money")
        {
            Destroy(collision.gameObject);
            gameController.CountMoney();
        }
    }
}
