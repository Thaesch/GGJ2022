using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{

    public delegate void SpawnEvent(Ghost ghost);
    public SpawnEvent OnSpawn;

    [SerializeField]
    private Ghost ghostPrefab;

    [SerializeField]
    private Timer timer;

    [SerializeField]
    private GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        timer.OnTimeout += Spawn;
    }

    private void Spawn()
    {
        Ghost newGhost = Instantiate<Ghost>(ghostPrefab, spawnPoint.transform.position, Quaternion.identity);
        OnSpawn?.Invoke(newGhost);
        Debug.Log("Spawned a ghost");
    }

    public void IncreaseDifficulty(float decreaseTime)
    {

    }
}
