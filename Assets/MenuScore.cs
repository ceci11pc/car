using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{
  
 
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = "SCORE:   " + StaticVar.staticScore.ToString();
      
        Debug.Log("static varrrr Menu" + StaticVar.staticScore);
    }

    // Update is called once per frame
    void Update()
    {
      
       
    }


}