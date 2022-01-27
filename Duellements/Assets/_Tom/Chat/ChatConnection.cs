using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class ChatConnection : MonoBehaviourPunCallbacks
{

    [SerializeField] private UnityEvent<string, string> onTextRecieved;

    public void SendChatMessage(string text)
    {
        photonView.RPC("RecieveChatMessage", RpcTarget.All, text, PhotonNetwork.NickName);
    }

    [PunRPC]
    private void RecieveChatMessage(string text, string senderName)
    {
        onTextRecieved?.Invoke(text, senderName);
    }


}
