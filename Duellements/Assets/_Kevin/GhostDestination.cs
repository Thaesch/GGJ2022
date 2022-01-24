using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostDestination : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    public void Start()
    {
        if (PhotonNetwork.IsConnected && !photonView.IsMine)
        {
            navMeshAgent.enabled = false;
        }
        else
        {
            navMeshAgent.SetDestination(Vector3.zero);
        }
    }

    public void SetDestination(PathFindingPoint destination)
    {
        navMeshAgent.SetDestination(destination.transform.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PathFindingPoint>() != null && !other.GetComponent<PathFindingPoint>().IsFountainOfLife)
        {
            PathFindingPoint nextDestination = other.GetComponent<PathFindingPoint>().GetRandomDestination();
            SetDestination(nextDestination);
        }
    }

}
