using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

   public GameObject startButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void ClickStart()
    {
        SceneManager.LoadScene("Racer");
    }
}
