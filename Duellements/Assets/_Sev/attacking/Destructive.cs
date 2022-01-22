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

        Damagable dmg = collider.GetComponent<Damagable>();
        if (dmg != null)
        {
            dmg.Damage(Damage, element);
            OnHit(dmg);
        }
    }
}
