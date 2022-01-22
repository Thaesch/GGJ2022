using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimeCooldownDecrease : DifficultyIncreaser
{
    
    [SerializeField]
    private List<float> decreaseTimes;
  
    override
        protected void SetConnection(GhostSpawn gs)
    {
        //OnDifficultyIncrease += gs.DecreaseCooldown;
    }

    override
        protected void DoYourWork()
    {
        float decreaseTime = decreaseTimes[0];
        OnDifficultyIncrease?.Invoke(new SpawnCDReductionCmd(decreaseTime));
        decreaseTimes.RemoveAt(0);
    }

}
