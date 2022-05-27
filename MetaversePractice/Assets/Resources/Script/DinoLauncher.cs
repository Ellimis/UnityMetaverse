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
        Debug.Log(PhotonNetwork.NickName + "�� �ȳ��ϼ���.");

        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("�̹� ������ �������ֽ��ϴ�.");
            PhotonNetwork.JoinLobby();
        }
        else
        {
            Debug.Log("���� ���� �õ�");
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("������ ���� ���� ����");
        Debug.Log("���� �κ� �����մϴ�.");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���ӿ� �����߽��ϴ�.");
        lobbyScene.SetActive(true);
    }
}
