using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TImer : MonoBehaviour
{

    public float timeRemaining = 0;
    public bool timerIsRunning = false;

    public string levelName;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelName == "level1"){
            if (timerIsRunning && PlayerPrefs.GetInt("Level1Completed", 0) == 1)
            {
                if (timeRemaining >= 0)
                {
                    timeRemaining += Time.deltaTime;

                    DisplayTime(timeRemaining);
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;
                }
            }
        }
        else if(levelName == "level2"){
            if (timerIsRunning && PlayerPrefs.GetInt("Level2Completed", 0) == 1)
            {
                if (timeRemaining >= 0)
                {
                    timeRemaining += Time.deltaTime;

                    DisplayTime(timeRemaining);
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;
                }
            }
        }
        else if(levelName == "level3"){
            if (timerIsRunning && PlayerPrefs.GetInt("Level3Completed", 0) == 1)
            {
                if (timeRemaining >= 0)
                {
                    timeRemaining += Time.deltaTime;

                    DisplayTime(timeRemaining);
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;
                }
            }
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds, milliseconds);
        if(levelName == "level1"){
            PlayerPrefs.SetFloat("Level1Time", timeToDisplay);
        }
        else if(levelName == "level2"){
            PlayerPrefs.SetFloat("Level2Time", timeToDisplay);
        }
        else if(levelName == "level3"){
            PlayerPrefs.SetFloat("Level3Time", timeToDisplay);
        }
    }
}
