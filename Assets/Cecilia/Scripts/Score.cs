using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Score : MonoBehaviour
{
    public int InitialScore;
    public bool ScoreOn = false;
    public Text ScoreText;

    void Start()
    {
        ScoreOn = true;
    }

    public void SetScore(int score)
    { 
        ScoreText.text = "SCORE: " + score.ToString();
    }
}
