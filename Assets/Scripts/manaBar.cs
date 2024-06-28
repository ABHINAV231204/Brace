using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class manaBar : MonoBehaviour
{
    // Start is called before the first frame update
   public Slider slider;
   public GameObject healthbar;

    public Gradient grd;
    public Image fill;

    public void setMaxMana(float max){
        slider.maxValue = max;
        fill.color = grd.Evaluate(1f);
    }
    public void setMana(float value)
    {
        slider.value = value;
        fill.color = grd.Evaluate(slider.normalizedValue);
    }
    public void enable(bool val){
        healthbar.SetActive(val);
    }
}
