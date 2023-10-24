using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
        
    public GameObject menu;
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnPlayButtonOnPause()
    {
        
        menu = GameObject.Find("PauseMenuCanvas Variant(Clone)");
        Destroy(menu);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }



}
