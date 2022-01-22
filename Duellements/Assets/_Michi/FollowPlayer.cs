using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 15;
    public float maxCameraDistance = 20;
    public float minCameraDistance = 10;
    public float mouseWheelSenistivity = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float wheelMovement = Input.GetAxis("Mouse ScrollWheel");
        cameraDistance = cameraDistance + (wheelMovement * mouseWheelSenistivity);
        if (cameraDistance > maxCameraDistance)
        {
            cameraDistance = maxCameraDistance;
        } else if (cameraDistance < minCameraDistance)
        {
            cameraDistance = minCameraDistance;
        }
        transform.position = player.transform.position + new Vector3(0, cameraDistance, -5);
    }
}
