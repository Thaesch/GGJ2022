using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReleaseFXSpawn : MonoBehaviour
{

    [SerializeField]
    private GhostReleaseFX ghostReleaseFX;

    [SerializeField]
    private Vector3 spawnPosition = new Vector3(2, -2, 3.5f);

    public void Spawn()
    {
        GhostReleaseFX grfx = Instantiate<GhostReleaseFX>(ghostReleaseFX, transform);
        grfx.transform.position = spawnPosition;
    }

}
