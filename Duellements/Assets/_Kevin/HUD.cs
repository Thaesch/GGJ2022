using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField]
    private FountainOfLife fountainOfLife;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private GameObject sucessMsg;

    [SerializeField]
    private GameObject defeatMsg;

    public void Start()
    {
        fountainOfLife.OnGameOver += OnGameOver;
        fountainOfLife.OnSuccess += OnSuccess;
    }

    public void OnGameOver()
    {
        background.GetComponent<Image>().enabled = true;
        defeatMsg.GetComponent<Image>().enabled = true;
    }

    public void OnSuccess()
    {
        background.GetComponent<Image>().enabled = true;
        sucessMsg.GetComponent<Image>().enabled = true;
    }

}
