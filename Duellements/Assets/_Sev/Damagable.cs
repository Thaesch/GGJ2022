using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{

    public delegate void Damaged(float damange);
    public event Damaged OnDamaged;

    public void Damage(float damage)
    {
        OnDamaged(damage);
    }

}
