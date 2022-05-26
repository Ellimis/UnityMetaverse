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
        string s = "�ȳ��ϼ��� " + PhotonNetwork.NickName + "��, " + count + "���� �������ֽ��ϴ�.";
        lobbyText.text = s;
    }

    public void findRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("���� �������� �� �� �ִ� ���� �����ϴ�. �� ���� �����մϴ�.");
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4, EmptyRoomTtl = 0 };
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("���ο� �뿡 �����߽��ϴ�.");

        roomScene.SetActive(true);
    }
}
