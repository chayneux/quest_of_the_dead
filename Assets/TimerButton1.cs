using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerButton1 : MonoBehaviour
{
    public TMP_Text buttonText = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("Level1Completed " + PlayerPrefs.GetInt("Level1Completed", 0));
        Debug.Log("Float" + PlayerPrefs.GetFloat("Level1Time", 0));
        if (PlayerPrefs.GetInt("Level1Completed", 0) == 1)
        {
            float level1Time = PlayerPrefs.GetFloat("Level1Time", 0);
            int level1TimeInt = (int)level1Time;
            string level1TimeStr = level1TimeInt.ToString();
            buttonText.text = "Timer : " + level1TimeStr.ToString() + "s";
        }

    }
}
