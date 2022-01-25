using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HUD : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private FountainOfLife fountainOfLife;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private GameObject sucessMsg;

    [SerializeField]
    private GameObject defeatMsg;

    public void Start()
    {
        fountainOfLife.OnGameOver += OnGameOver;
        fountainOfLife.OnSuccess += OnSuccess;
    }

    public void OnGameOver()
    {
        photonView.RPC("GameOverRequest", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void GameOverRequest()
    {
        background.GetComponent<Image>().enabled = true;
        defeatMsg.GetComponent<Image>().enabled = true;
    }

    [PunRPC]
    private void SuccessRequest()
    {
        background.GetComponent<Image>().enabled = true;
        sucessMsg.GetComponent<Image>().enabled = true;
    }

    public void OnSuccess()
    {
        photonView.RPC("SuccessRequest", RpcTarget.AllBuffered);
    }

}
