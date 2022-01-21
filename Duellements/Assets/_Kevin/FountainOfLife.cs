using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainOfLife : MonoBehaviour
{

    [SerializeField]
    private int lifeLeft = 100;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("foo");
        lifeLeft -= 1; // Maybe: other.GetComponent<Ghost>().Damage ?
    }

}
