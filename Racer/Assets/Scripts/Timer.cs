using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {

    private float startTime = 0.0f;

    private int currentMinute;

    public GameObject TimeText;

        
    // Use this for initialization
	void Start () {

      //  startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        startTime += Time.deltaTime;


        UpdateTimeView();
    }

    private void UpdateTimeView()
    {
        int intTime = (int)startTime;
        int minutes = intTime / 60;
        currentMinute = minutes;
        int seconds = intTime % 60;
        float fraction = startTime * 1000;
        fraction = (fraction % 1000)/10;
        string timeText = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);

        TimeText.gameObject.GetComponent<UnityEngine.UI.Text>().text = timeText;
    }

    public int GetCurrentMinute()
    {
        return currentMinute/2;
    }
}
