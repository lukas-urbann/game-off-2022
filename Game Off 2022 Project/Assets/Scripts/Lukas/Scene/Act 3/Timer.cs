using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 180;
    private string timeRemainingString = "XXX";
    private TMP_Text timeRemainingText;

    public GameObject player, gameOverScreen;

    private void Start()
    {
        timeRemainingText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (timeRemaining <= 0)
        {
            //End.GameOver();
            player.GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameOverScreen.SetActive(true);
            
            timeRemaining = 0;
            TimeToText();
        }
        else
        {
            timeRemaining -= UnityEngine.Time.deltaTime * 1;
            TimeToText();
        }
    }
    private void TimeToText()
    {
        timeRemainingString = ((int)timeRemaining / 60) + ":" + ((int)timeRemaining % 60).ToString("00");
            
        timeRemainingText.text = timeRemainingString;
    }
}
