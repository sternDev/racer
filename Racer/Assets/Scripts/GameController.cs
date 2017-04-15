using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    private int moneyCount = 0;
    private Text moneyText;
    private Text levelText;
    private int level = 1;

    private void Start()
    {
        moneyText = GameObject.Find("Money Counter").GetComponent<Text>();
        levelText = GameObject.Find("Level Counter").GetComponent<Text>();
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

    public int GetLevel()
    {
        return level;
    }
}
