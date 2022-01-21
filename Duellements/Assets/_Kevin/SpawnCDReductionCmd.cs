using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCDReductionCmd : DifficultyIncreasementCmd
{

    private float reductionTime;
    public float ReductionTime
    {
        get { return reductionTime; }
        set { reductionTime = value; }

    }

    public SpawnCDReductionCmd(float reductionTime)
    {
        this.reductionTime = reductionTime;
    }

}
