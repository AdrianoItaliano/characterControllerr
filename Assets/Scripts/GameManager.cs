using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool gamePaused = false, endGame = false, win=false;
    public int timeToEnd;
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        if(timeToEnd <= 0)
        {
            timeToEnd = 100;
        }

        Debug.Log("Time to end:" + timeToEnd + ".");
        InvokeRepeating("Stopper",2 ,1);

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (!gamePaused)
            {
                gamePaused = true;
                Time.timeScale = 0f;
                Debug.Log("Game is paused");
            }
            else
            {
                gamePaused = false;
                Time.timeScale = 1f;
                Debug.Log("Game is running");
            }
        }


    }
    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time:" + timeToEnd + " s.");
        if(timeToEnd<=0)
        {
            timeToEnd = 0;
            endGame = true;
            if(endGame)
            {
               EndGame();
            }
        }
    }

    private void EndGame()
    {
        CancelInvoke("Stopper");
        if(win)
        {
            Debug.Log("You win! Reload?");
        }
        else
        {
            Debug.Log("You loose, Reload?");
            gamePaused = true;
        }
    }
}
