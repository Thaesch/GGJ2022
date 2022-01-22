using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Projectile projectile;
    public Transform spawnPosition;
    public float minBlockTime = 0.3f;

    private float blockTime = 0;

    // Update is called once per frame
    void Update()
    {

        PhotonView pv = GetComponent<PhotonView>();

        blockTime -= Time.deltaTime;
        if (Input.GetMouseButton(0) && blockTime <= 0 && (!PhotonNetwork.IsConnected || pv.IsMine))
        {
            blockTime = minBlockTime;
            GameObject instance =  GameObject.Instantiate<GameObject>(projectile.gameObject, spawnPosition.position, spawnPosition.rotation);
        }
    }
}
