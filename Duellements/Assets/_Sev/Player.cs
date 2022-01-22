using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof (PlayerController))]
[RequireComponent(typeof (Shoot))]
public class Player : MonoBehaviour
{

    public Element element = Element.NORMAL;

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
