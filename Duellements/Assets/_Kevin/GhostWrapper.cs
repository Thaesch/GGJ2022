using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWrapper : MonoBehaviour
{

    [SerializeField]
    private GhostSpawn[] ghostSpawns;

    // Start is called before the first frame update
    void Start()
    {
        ConnectSpawnEvents();
    }

    private void ConnectSpawnEvents()
    {
        foreach(GhostSpawn gs in ghostSpawns)
        {
            gs.OnSpawn += AddGhost;
        }
    }

    private void AddGhost(Ghost ghost)
    {
        ghost.transform.parent = this.transform;
    }


}
