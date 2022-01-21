using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    public float Damage = 1.0f;
    public float Speed = 1.0f;
    public float Lifetime = 5.0f;


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
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider collider)
    {

        Damagable dmg = collider.GetComponent<Damagable>();
        if(dmg != null)
        {
            dmg.Damage(Damage);
        }

        SelfDestruct();
    }

}
