using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Timer))]
public class LobbyFountain : MonoBehaviour
{

    private Timer waitForPlayerReadyTimer;

    [SerializeField] private UnityEvent onPlayerReady;

    private void Start()
    {
        waitForPlayerReadyTimer = GetComponent<Timer>();
        waitForPlayerReadyTimer.OnTimeout += SetPlayerReady;
    }

    private void OnTriggerEnter(Collider other)
    {
        waitForPlayerReadyTimer.Run();
    }
    private void OnTriggerExit(Collider other)
    {
        waitForPlayerReadyTimer.Stop();
    }

    private void SetPlayerReady()
    {
        onPlayerReady?.Invoke();
    }
}
