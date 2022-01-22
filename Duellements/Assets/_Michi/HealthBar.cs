using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    

    // sets max health and also sets current health to max health
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // sets health
    public void setHealth(float health)
    {
        slider.value = health;
    }
}
