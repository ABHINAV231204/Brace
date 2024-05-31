using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public void setMaxHealth(int max){
        slider.maxValue = max;
    }
    public void setHealth(int value)
    {
        slider.value = value;
    }
}
