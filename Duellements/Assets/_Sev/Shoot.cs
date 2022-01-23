using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class ActionEvent : UnityEvent<string, GameObject> { }

public class Shoot : MonoBehaviour
{

    public ActionEvent OnShot;

    public Projectile projectile;
    public Transform spawnPosition;
    public float minBlockTime = 0.3f;

    private float blockTime = 0;

    // Update is called once per frame
    void Update()
    {

        PhotonView pv = GetComponent<PhotonView>();

        blockTime -= Time.deltaTime;
        if (Input.GetMouseButton(0) && blockTime <= 0 )
        {

            if (!PhotonNetwork.IsConnected)
            {
                GameObject.Instantiate<GameObject>(projectile.gameObject, spawnPosition.position, spawnPosition.rotation);
            }
            else if(pv.IsMine)
            {
                PhotonNetwork.Instantiate("prefabs/projectiles/"+ projectile.name, spawnPosition.position, spawnPosition.rotation);
            }


            blockTime = minBlockTime;
        }
    }
}
