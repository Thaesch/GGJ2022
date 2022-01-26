using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




    public class StartConnection : MonoBehaviourPunCallbacks
    {

        [SerializeField] private Button connectionButton;
        [SerializeField] private TMPro.TMP_InputField nickNameInput;

        private string gameVersion = "1.0";

        [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
        [SerializeField] private byte maxPlayersPerRoom = 5;

        private bool isConnecting;

        const string nickNamePrefKey = "PlayerNickName";

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            Application.targetFrameRate = 90;
        }

        private void Start()
        {
            if(PlayerPrefs.HasKey(nickNamePrefKey))
            {
                string nickName = PlayerPrefs.GetString(nickNamePrefKey);
                nickNameInput.text = nickName;
                PhotonNetwork.NickName = nickName;
            }
            connectionButton.interactable = true;
        }

        public void Connect()
        {
            connectionButton.interactable = false;

            string nickName = nickNameInput.text;
            PlayerPrefs.SetString(nickNamePrefKey, nickName);
            PhotonNetwork.NickName = nickName;

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                isConnecting = PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }


        public override void OnConnectedToMaster()
        {

            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
                isConnecting = false;
            }
        }


        public override void OnDisconnected(DisconnectCause cause)
        {
            connectionButton.interactable = true;
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                PhotonNetwork.LoadLevel("Lobby");
            }
        }

        public void CloseGame()
        {
            Application.Quit();
        }

    }
