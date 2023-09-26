using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxSpeed(float speed)
    {
        slider.maxValue = speed;
        slider.value = speed;

        fill.color = gradient.Evaluate (1f) ;

    }

    public void SetSpeed(float speed)
    {
        slider.value = speed;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

}
