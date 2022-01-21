using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public delegate void TimeoutEvent();
    public TimeoutEvent OnTimeout;

    [SerializeField]
    protected int waittime;
    public int Waittime
    {
        get { return waittime; }
        set { waittime = value; }
    }

    [SerializeField]
    protected bool startOnAwake = false;

    [SerializeField]
    protected bool oneShot = false;

    protected float timeout;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (startOnAwake)
        {
            SetTimeOut();
            Debug.Log("Started Timeout");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive && (Time.time > timeout))
        {
            OnTimeOut();
        }
    }

    protected virtual void SetTimeOut()
    {
        timeout = Time.time + waittime;
        isActive = true;
    }

    private void OnTimeOut()
    {
        if (!oneShot) {
            SetTimeOut();
        }
        else
        {
            isActive = false;
        }

        OnTimeout?.Invoke();
        Debug.Log("Timeout");
    }

    public void Stop()
    {
        isActive =false;
    }

    public void Run()
    {
        SetTimeOut();
    }

}
