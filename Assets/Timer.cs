using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float InitialTime;
    public static float TimeLeft;
    public bool TimerOn = false;

    public Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
        //lo pongo aca porque si no uso static en la variable, no la ve el gameending

        TimeLeft = InitialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }
        else
        {
            Debug.Log("TimeisUP");
            TimeLeft = 0;
            TimerOn = false;
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
