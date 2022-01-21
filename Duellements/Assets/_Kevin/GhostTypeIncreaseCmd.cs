using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTypeIncreaseCmd : DifficultyIncreasementCmd
{

    private int unlockedType;
    public int UnlockedType
    {
        get { return unlockedType; }
        set { unlockedType = value; }
    }

    public GhostTypeIncreaseCmd(int unlockedType)
    {
        this.unlockedType = unlockedType;
    }

}
