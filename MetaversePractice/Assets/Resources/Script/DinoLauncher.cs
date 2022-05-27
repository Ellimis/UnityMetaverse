using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class DinoLauncher : MonoBehaviourPunCallbacks
{
    public InputField nicknameField;
    public GameObject lobbyScene;

    private string gameVersion = "1";

    private void Awake()
    {
        PlayerPrefs.SetInt("PlayerCount", 0);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Connect()
    {
        if (nicknameField.text.Equals(string.Empty)) return;
        PhotonNetwork.NickName = nicknameField.text;
        Debug.Log(PhotonNetwork.NickName + "님 안녕하세요.");

        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("이미 서버에 접속해있습니다.");
            PhotonNetwork.JoinLobby();
        }
        else
        {
            Debug.Log("서버 접속 시도");
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("마스터 서버 접속 성공");
        Debug.Log("이제 로비에 접속합니다.");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비 접속에 성공했습니다.");
        lobbyScene.SetActive(true);
    }
}
