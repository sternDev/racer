using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    private int moneyCount = 0;
    private Text moneyText;
    private Text levelText;
    private int level = 1;
    

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
        PlayerPrefs.SetString("test","Name: Jasmin, Level: "+GetLevel()+", Zeit: "+ timeController.GetFormattedTime());
        PlayerPrefs.SetString("placeTime1", timeController.GetFormattedTime());
        PlayerPrefs.SetInt("placePoints1", timeController.GetTime());
        PlayerPrefs.SetString("placeName1", "Jasmin");
        PlayerPrefs.SetInt("placeLevel1", GetLevel());
    }
}
