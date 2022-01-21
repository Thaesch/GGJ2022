using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyIncreaser : MonoBehaviour
{
    public delegate void IncreaseEvent(DifficultyIncreasementCmd difficultyIncreasementCmd);
    public IncreaseEvent OnDifficultyIncrease;

    [SerializeField]
    protected Timer timer;

    [SerializeField]
    protected List<int> waittimes;

    [SerializeField]
    protected GhostSpawn[] ghostSpawns;
    
    // Start is called before the first frame update
    void Start()
    {
        timer.OnTimeout += IncreaseDifficulty;
        ConnectGhostSpawns();
        timer.Run();
    }

    protected virtual void IncreaseDifficulty()
    {

        if (waittimes.Count > 1)
        {
            float waittime = waittimes[0];
            timer.Waittime = waittime;
            timer.Run();
            waittimes.RemoveAt(0);
            DoYourWork();
        }
        else // Last increase reached
        {
            timer.Stop();
        }
    }
    
    protected void ConnectGhostSpawns()
    {
        foreach (GhostSpawn gs in ghostSpawns)
        {
            SetConnection(gs);
        }
    }

    protected virtual void SetConnection(GhostSpawn gs)
    {

    }

    protected virtual void DoYourWork() { 

    }

}
