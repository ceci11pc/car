using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateWebLimit : MonoBehaviour
{
    public static int targetFrameRate;
    
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 24;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
