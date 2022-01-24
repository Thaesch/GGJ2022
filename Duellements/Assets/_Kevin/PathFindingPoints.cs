using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingPoints : MonoBehaviour
{

    private static PathFindingPoints _instance;

    public static PathFindingPoints Instance { get { return _instance; } }

    [SerializeField]
    private PathFindingPoint leftSpawnInitiPoint;

    [SerializeField]
    private PathFindingPoint rightSpawnInitiPoint;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public PathFindingPoint InitialPoint(bool left)
    {
        PathFindingPoint pathFindingPoint = left ? leftSpawnInitiPoint : rightSpawnInitiPoint;

        return pathFindingPoint;
    }


}
