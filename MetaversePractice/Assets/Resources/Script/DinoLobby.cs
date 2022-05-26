using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class DinoLobby : MonoBehaviourPunCallbacks
{
    public Text lobbyText;
    public GameObject roomScene;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string result = string.Empty;
        int count = PhotonNetwork.CountOfPlayers;
        string s = "안녕하세요 " + PhotonNetwork.NickName + "님, " + count + "명이 접속해있습니다.";
        lobbyText.text = s;
    }

    public void findRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("현재 무작위로 들어갈 수 있는 방이 없습니다. 새 방을 생성합니다.");
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4, EmptyRoomTtl = 0 };
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("새로운 룸에 접속했습니다.");

        roomScene.SetActive(true);
    }
}
