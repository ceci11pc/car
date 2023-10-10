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
    // Start is called before the first frame update
    void Start()
    {
        ScoreOn = true;
       
        

    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    public void SetScore(int score)
    {
       
        ScoreText.text = score.ToString();
        Debug.Log("SCORE");

    }
}
