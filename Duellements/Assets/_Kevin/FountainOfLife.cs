using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainOfLife : MonoBehaviour
{

    [SerializeField]
    private int lifeLeft = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ghost>())
        {
            lifeLeft -= 1;
            other.GetComponent<Ghost>().Released();
        }
        

    }

}
