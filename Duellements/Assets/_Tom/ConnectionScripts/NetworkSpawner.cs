using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSpawner : MonoBehaviour
{

    public static GameObject Instantiate(string prefabName, Vector3 position, Quaternion rotation)
    {
        return PhotonNetwork.Instantiate(prefabName, position, rotation);
    }

    public static void Destroy(GameObject gameObject)
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
