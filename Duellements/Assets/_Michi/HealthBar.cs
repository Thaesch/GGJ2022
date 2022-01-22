using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Ghost target;


    private void Start()
    {
        setMaxHealth(target.MaxLives);
    }

    private void Update()
    {
        setHealth(target.Health);
    }

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
