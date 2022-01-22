using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 15;
    public float maxCameraDistance = 20;
    public float minCameraDistance = 10;
    public float mouseWheelSenistivity = 10;
    public float angle = 80;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(angle, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position 
        float wheelMovement = Input.GetAxis("Mouse ScrollWheel");
        cameraDistance -= (wheelMovement * mouseWheelSenistivity);
        Debug.Log("Distanz: " + cameraDistance);
        Debug.Log("Maus: " + wheelMovement);
        Debug.Log("Sensitivity: " + mouseWheelSenistivity);
        if (cameraDistance > maxCameraDistance)
        {
            cameraDistance = maxCameraDistance;
        } else if (cameraDistance < minCameraDistance)
        {
            cameraDistance = minCameraDistance;
        }
        transform.position = player.transform.position;
        transform.Translate(-Vector3.forward * cameraDistance);
    }
}
