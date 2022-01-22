using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConnection : MonoBehaviour
{

    [SerializeField] private Transform spawnPositions;

    void Start()
    {
        NetworkSpawner.Instantiate("Player", spawnPositions.GetChild(PhotonNetwork.CurrentRoom.PlayerCount - 1).position, Quaternion.identity);
    }

}
