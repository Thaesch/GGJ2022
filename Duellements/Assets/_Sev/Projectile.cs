using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    public float Damage = 1.0f;
    public float Speed = 1.0f;


    protected void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);
    }

}
