using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCarsMovement : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = NextFloat(20f, 200f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime * Vector3.forward, Space.World);

     
    }

    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    
}
