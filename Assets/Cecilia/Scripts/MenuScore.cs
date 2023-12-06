using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {      
        scoreText.text = "SCORE:   " + StaticVar.staticScore.ToString();
    }
}