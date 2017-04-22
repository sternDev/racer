using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    private int moneyCount = 0;
    private Text moneyText;
    private Text levelText;
    private int level = 1;

    Highscore[] highscoreTable = new Highscore[10];

    private Timer timeController;

    private void Start()
    {
        moneyText = GameObject.Find("Money Counter").GetComponent<Text>();
        levelText = GameObject.Find("Level Counter").GetComponent<Text>();

        timeController = GameObject.Find("Time").GetComponent<Timer>();
    }

    public void CountMoney()
    {
        moneyCount++;
        moneyText.text = moneyCount.ToString();
    }

    public void LevelUp()
    {
        level++;
        levelText.text = "Level "+level.ToString();
    } 

    public void MinimizeMoney( int money)
    {
        moneyCount -= money;
        moneyText.text = moneyCount.ToString();
    }
    public int GetMoney()
    {
        return moneyCount;
    }

    public int GetLevel()
    {
        return level;
    }

    public void AddHighscore()
    {
        Highscore highscore = new Highscore();
        highscore.SetPlayedTime(timeController.GetTime());
        highscore.SetPlayerName("Mistekiste");
        highscore.SetReachedLevel(GetLevel());
        Highscore[] highscoreTest = Serializer.Load<Highscore[]>("test.json");

        int i = 0;
        foreach (Highscore hs in highscoreTest)
        {
            
            if(hs == null)
            {
                highscoreTest[i] = highscore;
            }
            i++;
        }

        Serializer.Save<Highscore[]>("test.json", highscoreTest);
    }
}
