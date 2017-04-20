using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {



	// Use this for initialization
	void Start () {

        string highscoreText = "Highscore:\n";
        for (int i = 1; i <= 3; i++)
        {
            if (PlayerPrefs.GetString("placeName" + i) != "") {

                highscoreText += i + ". Platz: " + PlayerPrefs.GetString("placeName" + i) + "\n";
            }
        }
        GetComponent<Text>().text = highscoreText;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
