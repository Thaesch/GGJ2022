using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.4f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,Time.deltaTime * rotationSpeed);
        Debug.Log("Rotation: " + transform.rotation);
    }
}
