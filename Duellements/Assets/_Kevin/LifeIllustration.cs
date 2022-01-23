using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeIllustration : MonoBehaviour
{

    [SerializeField]
    private FountainOfLife fountainOfLife;

    public Slider slider;

    private void Start()
    {
        fountainOfLife.OnGhostReleased += DecreaseLife;
        slider.maxValue = fountainOfLife.LifeLeft;
    }
        
    // sets max health and also sets current health to max health
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // sets health
    public void DecreaseLife()
    {
        slider.value -= 1;
    }



}
