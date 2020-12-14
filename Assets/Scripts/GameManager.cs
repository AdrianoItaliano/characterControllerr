using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd, points = 0, goldKeys = 0, redKeys=0, greenKeys=0;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public Text txt;

    AudioSource audioSource;

    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;

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

        audioSource = GetComponent<AudioSource>();

        Debug.Log("Time: " + timeToEnd + " s");
        InvokeRepeating("Stopper", 2, 1);
    }
    public void AddKey(KeyColor color)
    {
        if(color == KeyColor.Gold)
        {
            goldKeys++;
        }
        else if (color == KeyColor.Green)
        {
            greenKeys++;
        }
        else if (color == KeyColor.Red)
        {
            redKeys++;
        }

    }
    public void AddPoints(int points)
    {
        this.points += points;
    }
    public void AddTime(int time)
    {
        timeToEnd += time;
    }

    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime, 1);
    }

    void Update()
    {
        txt.text = "Czas do końca " +timeToEnd.ToString()+ " sekund";
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Gold keys:" +goldKeys+", Green keys: "+greenKeys+", Red keys: "+redKeys);
            Debug.Log("Actual time:"+timeToEnd);
            Debug.Log("Points: " + points);
        }
    }
    
    void Stopper()
    {
        timeToEnd--;
        //Debug.Log("Time: " + timeToEnd + " s");
        
        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        PlayClip(pauseClip);
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Reload?");
        } 
        else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }

    public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
    }
}
