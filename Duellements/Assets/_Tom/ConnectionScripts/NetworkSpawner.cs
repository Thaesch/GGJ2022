using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSpawner
{

    public static T Instantiate<T>(string prefabName, Vector3 position, Quaternion rotation)
    {
        return PhotonNetwork.Instantiate("prefabs/" + prefabName, position, rotation).GetComponent<T>();
    }

    public static GameObject Instantiate(string prefabName, Vector3 position, Quaternion rotation)
    {
        return PhotonNetwork.Instantiate("prefabs/" + prefabName, position, rotation);
    }

    public static void Destroy(GameObject gameObject)
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
