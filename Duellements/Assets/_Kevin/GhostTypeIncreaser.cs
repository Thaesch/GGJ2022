using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTypeIncreaser : DifficultyIncreaser
{

    private int currentDifficulty = 0;

    override
      protected void DoYourWork()
    {
        currentDifficulty++;
        OnDifficultyIncrease?.Invoke(new GhostTypeIncreaseCmd(currentDifficulty));
    }

    override
        protected void SetConnection(GhostSpawn gs)
    {
        //OnDifficultyIncrease += gs.UnlockDifficulty;
    }

}
