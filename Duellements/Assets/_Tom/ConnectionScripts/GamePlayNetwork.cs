using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class GamePlayNetwork : MonoBehaviourPunCallbacks
    {

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene("Connection");
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player other)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                // Send Start Game Event if player Number is 4
                if(PhotonNetwork.CurrentRoom.PlayerCount == 4)
                {

                }
            }
        }


        public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
        {
            
        }

    }