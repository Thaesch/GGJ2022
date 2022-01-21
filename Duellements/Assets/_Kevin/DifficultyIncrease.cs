using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyIncrease : MonoBehaviour
{
    public delegate void IncreaseEvent(float decreaseTimes);
    public IncreaseEvent OnDifficultyIncrease;

    [SerializeField]
    private Timer timer;

    [SerializeField]
    private List<int> waittimes;

    [SerializeField]
    private List<float> decreaseTimes;

    [SerializeField]
    GhostSpawn[] ghostSpawns;

    // Start is called before the first frame update
    void Start()
    {
        timer.OnTimeout += IncreaseDifficulty;
        ConnectGhostSpawns();
    }

    private void IncreaseDifficulty()
    {
        if(decreaseTimes.Count > 1)
        {
            float decreaseTime = decreaseTimes[0];
            float waittime = waittimes[0];
            OnDifficultyIncrease?.Invoke(decreaseTime);
            decreaseTimes.RemoveAt(0);
            waittimes.RemoveAt(0);
        }
        else // Last increase reached
        {
            timer.Stop();
        }
    }

    private void ConnectGhostSpawns()
    {
        foreach(GhostSpawn gs in ghostSpawns)
        {
            OnDifficultyIncrease += gs.IncreaseDifficulty;
        }
    }
}
