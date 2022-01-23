using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTimer : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer.OnTimeout += Remove;
    }

    private void Remove()
    {
        Destroy(this.gameObject);
    }
}
