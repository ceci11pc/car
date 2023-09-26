using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterButtons : MonoBehaviour
{
    public MeterScript speedMeter; //this allows you to link this script to the meter's script via the inspector
    public int currentSpeed; //defines the variable you'd like to keep track of
    public int maxSpeed = 80; //defines the maximum value of your variable (keep it at a multiple of 8 so that it matches the meter's sections)


    void Start()
    {
        currentSpeed = maxSpeed; //sets your variable to maximum from the start
        speedMeter.SetMaxSpeed(maxSpeed); //sets your meter's fill to maximum from the start

    }


    void FixedUpdate()
    {
        speedMeter.SetSpeed(currentSpeed); //links your variable to the meter's fill

    }

    public void Increase()
    {

            currentSpeed += 10; //increases the variable's value by 10
    }

    public void Decrease()
    {

            currentSpeed -= 10; //decreases the variable's value by 10
    }
}
