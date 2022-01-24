using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingPoint : MonoBehaviour
{
    [SerializeField]
    private PathFindingPoint[] reachablePoints;

    [SerializeField]
    private bool isFountainOfLife = false;
    public bool IsFountainOfLife
    {
        get { return isFountainOfLife; }
    }

    public PathFindingPoint GetRandomDestination()
    {
        return reachablePoints[Random.Range(0, reachablePoints.Length-1)] ;
    }

}
