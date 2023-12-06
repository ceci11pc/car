using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float initialTime;
    public static float timeLeft;
    public bool timerOn = false;
    public Text timerText;
    public int gameJustEnded = 0;

    private int finnalCount;

    FMOD.Studio.EventInstance gameover;

    void Start()
    {
        timerOn = true;

        timeLeft = initialTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            updateTimer(timeLeft);     
        }
        else
        {   
            timeLeft = 0;
            timerOn = false;
            gameJustEnded++;
            endSound();
            Invoke("endScene", 1f);
        }

        if (timeLeft < 5 && timeLeft > 0 && finnalCount != Mathf.FloorToInt(timeLeft % 60))
        {
            finnalCount = Mathf.FloorToInt(timeLeft % 60);
            FMODUnity.RuntimeManager.PlayOneShot("event:/COUNTDOWN");
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void endScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    void endSound()
    {
        if (gameJustEnded == 1)
        {
            gameover = FMODUnity.RuntimeManager.CreateInstance("event:/GAMEOVER");
            gameover.start();
            gameover.release();  
        }
    }
}

