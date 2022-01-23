using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDDecreaserPowerUp : PowerUp
{

    [SerializeField]
    private float blockTimeDecrease = 0.2f;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        Debug.Log(other);
        if(other.GetComponent<Shoot>() != null)
        {
            Debug.Log("Shooter");
            other.GetComponent<Shoot>().BlockTimeDecrease(blockTimeDecrease);
            Destroy(this);
        }
    }

}
