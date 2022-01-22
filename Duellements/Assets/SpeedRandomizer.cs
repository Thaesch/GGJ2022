using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpeedRandomizer : MonoBehaviour
{

    [SerializeField]
    private float minSpeed = 1;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        float speed = Random.Range(minSpeed, maxSpeed);

        navMeshAgent.speed = speed;

        //Destroy(this);
    }

}
