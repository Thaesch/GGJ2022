using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MessageService : MonoBehaviour
{

    public static void ApplyDamage(PhotonView otherView, float damage, Element element)
    {
        otherView.RPC("Damage", otherView.Owner, damage, element);
    }

}
