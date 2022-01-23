using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{

    [SerializeField]
    private Timer timer;

    private void Start()
    {
        timer.OnTimeout += Remove;
    }

    private void Remove()
    {
        Destroy(this.gameObject);
    }


}
