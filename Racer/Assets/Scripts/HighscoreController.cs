using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {

    Highscore highscoreTable;
	// Use this for initialization
	void Start () {

        string highscoreText = "Highscore:\n";
        // highscoreTable = JsonUtility.FromJson<Highscore>(PlayerPrefs.GetString("highscoreObject"));


        Highscore[] highscoreTest = Serializer.Load<Highscore[]>("test.json");

        foreach (Highscore hs in highscoreTest)
        {

            if (hs != null)
            {


                highscoreText += "1. Platz: " + hs.GetPlayerName() +", Punkte: "+hs.GetPlayedTime()+ "\n";
            }
        }
           

        GetComponent<Text>().text = highscoreText;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
