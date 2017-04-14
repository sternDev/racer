using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    private int moneyCount = 0;
    private Text moneyText;

    private void Start()
    {
        moneyText = GameObject.Find("Money Counter").GetComponent<Text>();
    }

    public void CountMoney()
    {
        moneyCount++;
        moneyText.text = moneyCount.ToString();

    }

	
}
