using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainOfLife : MonoBehaviour
{

    public delegate void GhostReleased();
    public GhostReleased OnGhostReleased;

    [SerializeField]
    private GhostReleaseFXSpawn ghostReleaseFXSpawn;

    [SerializeField]
    private int lifeLeft = 100;

    private void Start()
    {
        OnGhostReleased += ghostReleaseFXSpawn.Spawn;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");

        if (other.GetComponent<Ghost>())
        {
            lifeLeft -= 1;
            other.GetComponent<Ghost>().Released();
            OnGhostReleased?.Invoke();
            Debug.Log("Should spawn");
        }

    }

}
