using Photon.Pun;
using System;
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

    //[SerializeField]
    //private GameObject spawnPoint;

    //[SerializeField]
    //private List<int> ghostDifficulties = new List<int>() { 0 };
      
    // Start is called before the first frame update
    void Start()
    {
        timer.OnTimeout += Spawn;
    }

    private void Spawn()
    {
        Ghost newGhost;
        if (PhotonNetwork.IsConnected)
            newGhost  = NetworkSpawner.Instantiate<Ghost>("Ghost", this.transform.position, Quaternion.identity);
        else
            newGhost = Instantiate<Ghost>(ghostPrefab, this.transform.position, Quaternion.identity);

        //newGhost.Init(ghostDifficulties[UnityEngine.Random.Range(0, ghostDifficulties.Count)]);
        OnSpawn?.Invoke(newGhost);
    }
    
    public void DecreaseCooldown(DifficultyIncreasementCmd spawnCDReductionCmd)
    {
        timer.Waittime -= ((SpawnCDReductionCmd)spawnCDReductionCmd).ReductionTime;
    }

    //public void UnlockDifficulty(DifficultyIncreasementCmd difficultyIncreasementCmd)
    //{
    //    if (! ghostDifficulties.Contains(((GhostTypeIncreaseCmd)difficultyIncreasementCmd).UnlockedType))
    //    {
    //        ghostDifficulties.Add(((GhostTypeIncreaseCmd)difficultyIncreasementCmd).UnlockedType);
    //    }
    //}

}
