using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Highscore{

    private string playerName;
    private float playedTime;
    private int reachedLevel;


    public void SetPlayerName(string playerName)
    {
        this.playerName = playerName;
    }


    public void SetPlayedTime(float playedTime)
    {
        this.playedTime = playedTime;
    }

    public void SetReachedLevel(int reachedLevel)
    {
        this.reachedLevel = reachedLevel;
    }
   
    public string GetPlayerName()
    {
        return this.playerName;
    }


    public float GetPlayedTime()
    {
        return this.playedTime;
    }

    public int GetReachedLevel()
    {
        return this.reachedLevel;
    }
}
