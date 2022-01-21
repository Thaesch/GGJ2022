using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTimer : Timer
{

    [SerializeField]
    private float minWaittime;

    [SerializeField]
    private float maxWaittime;

    override 
        protected void SetTimeOut()
    {
        base.SetTimeOut();
        timeout = Time.time + Random.Range(minWaittime, maxWaittime);
    }
    
}
