using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Damagable))]
public class Elemental : MonoBehaviour
{

    public float Health = 100;



    private void Start()
    {
        GetComponent<Damagable>().OnDamaged += TakeDamage;
    }

    private void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0) Destroy(gameObject);
    }

    private void OnDisable()
    {
        GetComponent<Damagable>().OnDamaged -= TakeDamage;
    }


}
