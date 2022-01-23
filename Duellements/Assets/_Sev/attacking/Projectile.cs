using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Destructive))]
public class Projectile : MonoBehaviourPunCallbacks
{

    public float Speed = 1.0f;
    public float Lifetime = 5.0f;

    public void OnEnable()
    {
        base.OnEnable();
        GetComponent<Destructive>().OnHit += Hit;
    }

    public void OnDisable()
    {
        base.OnDisable();
        GetComponent<Destructive>().OnHit -= Hit;
    }

    private void Hit(Damagable damagable)
    {
        SelfDestruct();
    }

    protected void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        Lifetime -= Time.deltaTime;
        if (Lifetime <= 0)
        {
            SelfDestruct();
        }
    }



    private void SelfDestruct()
    {
        if (PhotonNetwork.IsConnected && photonView.IsMine)
            PhotonNetwork.Destroy(gameObject);
        else
            Destroy(gameObject);

    }



}
