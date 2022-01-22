using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConnection : MonoBehaviour
{

    [SerializeField] private Transform spawnPositions;
    [SerializeField] private FollowPlayer followPlayerCamera;

    void Start()
    {
        if (!PhotonNetwork.IsConnected) { SceneManager.LoadScene("Connection"); followPlayerCamera.enabled = false; return; }
        followPlayerCamera.player = NetworkSpawner.Instantiate("Player", spawnPositions.GetChild(PhotonNetwork.CurrentRoom.PlayerCount - 1).position, Quaternion.identity).transform;
    }

}
