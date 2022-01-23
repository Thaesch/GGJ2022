using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeVisualization : MonoBehaviour
{
    [SerializeField]
    private FountainOfLife fountainOfLife;

    [SerializeField]
    private Timer internalTimer;

    public Slider slider;

    private void Start()
    {
        slider.maxValue = fountainOfLife.PlaytimeTimer.Waittime;
        slider.value = 0;
        internalTimer.OnTimeout += IncreaseSlider;
        internalTimer.Run();
    }

    private void IncreaseSlider()
    {
        slider.value += 1;
    }
}
