using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Damagable))]
public class Elemental : MonoBehaviour
{

    public Element element = Element.NORMAL;
    public float Health = 100;

    public float disadvantageMultier = 0.5f;
    public float advantageMultiplier = 1.5f;


    private void Start()
    {
        GetComponent<Renderer>().material.color = Elements.GetColorOf(element);
        GetComponent<Damagable>().OnDamaged += TakeDamage;
    }

    private void TakeDamage(float damage, Element incoming = Element.NORMAL)
    {
        Relation rel = Elements.RelationOf(incoming, element);

        if (rel == Relation.Advantage) damage *= advantageMultiplier;
        else if (rel == Relation.Disadvantage) damage *= disadvantageMultier;
        
        Health -= damage;
        if (Health <= 0) Destroy(gameObject);
    }

    private void OnDisable()
    {
        GetComponent<Damagable>().OnDamaged -= TakeDamage;
    }


}
