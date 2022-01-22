using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Destructive : MonoBehaviour
{

    public float Damage;
    public Element element = Element.NORMAL;

    public delegate void Hit(Damagable damagable);
    public event Hit OnHit;

    public void OnEnable()
    {
        if (!GetComponent<Collider>().isTrigger)
            Debug.LogError("Collider is no Trigger on Destructive.");
    }


    private void OnTriggerEnter(Collider collider)
    {
        PhotonView otherView = collider.GetComponent<PhotonView>();
        Damagable dmg = collider.GetComponent<Damagable>();
        if (dmg != null && otherView != null)
        {
            MessageService.ApplyDamage(otherView, Damage, element);
            OnHit(dmg);
        }
    }
}
