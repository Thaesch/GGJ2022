using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Marco;
using Photon.Pun;

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
    private bool isLeftOne = true;

    private int difficulty = 0;
    private int wave = 0;
    private Wave currentWave;

    [SerializeField] private List<Wave> difficulties = new List<Wave>();

    // Start is called before the first frame update
    void Start()
    {
        timer.OnTimeout += Spawn;
  
        SetupWave();
    }

    private void SetupWave()
    {
        if (difficulties.Count > 0)
        {
            currentWave = difficulties[difficulty];
        }
        else
        {
            difficulties.Add(new Wave()
            {
                Duration = 2,
                GhostHealth = 100,
                GhostPerWave = 1
            });
            currentWave = difficulties[0];
        }
        
        wave = currentWave.Duration;
    }

    private void Spawn()
    {
        wave--;
        if (wave < 0)
        {
            IncreaseDifficulty();
        }
        for (int i = 0; i < currentWave?.GhostPerWave; i++)
        {
            Ghost newGhost = null;
            if (PhotonNetwork.IsConnected)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    newGhost = NetworkSpawner.Instantiate<Ghost>("Ghost", this.transform.position, Quaternion.identity);
                    newGhost.GetComponent<GhostDestination>().SetDestination(PathFindingPoints.Instance.InitialPoint(isLeftOne));

                    OnSpawn?.Invoke(newGhost);
                }
            }
            else
            {
                newGhost = Instantiate<Ghost>(ghostPrefab, this.transform.position, Quaternion.identity);
                OnSpawn?.Invoke(newGhost);
            }

            if (newGhost != null)
            {
                newGhost.MaxLives = currentWave.GhostHealth;
            }
        }
    }

    public void DecreaseCooldown(DifficultyIncreasementCmd spawnCDReductionCmd)
    {
        timer.Waittime -= ((SpawnCDReductionCmd)spawnCDReductionCmd).ReductionTime;
    }

    private async void IncreaseDifficulty()
    {
        timer.Stop();
        while (GameObject.FindObjectsOfType<Ghost>().Any())
        {
            await Task.Yield();
        }
        
        difficulty = Mathf.Min(difficulty + 1, difficulties.Count - 1);
        SetupWave();
        timer.Run();
    }

    //public void UnlockDifficulty(DifficultyIncreasementCmd difficultyIncreasementCmd)
    //{
    //    if (! ghostDifficulties.Contains(((GhostTypeIncreaseCmd)difficultyIncreasementCmd).UnlockedType))
    //    {
    //        ghostDifficulties.Add(((GhostTypeIncreaseCmd)difficultyIncreasementCmd).UnlockedType);
    //    }
    //}

}
