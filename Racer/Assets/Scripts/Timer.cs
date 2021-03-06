﻿using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {

    private float startTime = 0.0f;

    private int currentMinute;

    public GameObject TimeText;
    private GameController gameController;
    private bool canLevelUp = false;

        
    // Use this for initialization
	void Start () {
        gameController = GameObject.Find("Game").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        startTime += Time.deltaTime;
        UpdateTimeView();
    }

    public String GetFormattedTime()
    {
        int intTime = (int)startTime;
        int minutes = intTime / 60;
        currentMinute = minutes;
        int seconds = intTime % 60;
        float fraction = startTime * 1000;
        fraction = (fraction % 1000) / 10;
        return String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }

    public int GetTime()
    {
        return (int)startTime;
    }

    private void UpdateTimeView()
    {
        int intTime = (int)startTime;
        int seconds = intTime % 60;

        TimeText.gameObject.GetComponent<UnityEngine.UI.Text>().text = GetFormattedTime();
        if(seconds%20 == 0 )
        {
            if (canLevelUp) {
                gameController.LevelUp();
                canLevelUp = false;
            }
        } else
        {
            canLevelUp = true;
        }
    }

    public int GetCurrentMinute()
    {
        return currentMinute/2;
    }
}
