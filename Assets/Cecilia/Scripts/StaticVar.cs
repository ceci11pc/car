using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVar : MonoBehaviour
{
    public static int staticScore = 0;
    
    public void UpdateScore(int score)
    {
       staticScore = score;
    }
}
