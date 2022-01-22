using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public delegate void Damaged(float damange, Element element);
    public event Damaged OnDamaged;

    [PunRPC]
    public void Damage(float damage, Element element)
    {
        OnDamaged(damage, element);
    }

}
