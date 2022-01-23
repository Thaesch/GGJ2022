using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainOfLife : MonoBehaviour
{

    public delegate void GhostReleased();
    public GhostReleased OnGhostReleased;

    public delegate void Success();
    public Success OnSuccess;

    public delegate void GameOver();
    public GameOver OnGameOver;

    [SerializeField]
    private GhostReleaseFXSpawn ghostReleaseFXSpawn;

    [SerializeField]
    private int lifeLeft = 100;

    [SerializeField]
    private Timer playtimeTimer;

    private void Start()
    {
        OnGhostReleased += ghostReleaseFXSpawn.Spawn;
        playtimeTimer.OnTimeout += CommunicateSuccess;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Ghost>())
        {
            lifeLeft -= 1;
            other.GetComponent<Ghost>().Released();
            OnGhostReleased?.Invoke();
            CheckGameOver();
        }
    }

    private void CheckGameOver()
    {
        if(lifeLeft <= 0)
        {
            OnGameOver?.Invoke();
        }
    }

    private void CommunicateSuccess()
    {
        Debug.Log("SUCCESS!");
        OnSuccess?.Invoke();
    }

}
