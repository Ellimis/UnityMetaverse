using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class DinoRoom : MonoBehaviourPunCallbacks
{
    public Text roomText;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        changeRoomInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("�÷��̾� " + newPlayer.NickName + " ����.");
        changeRoomInfo();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("�÷��̾� " + otherPlayer.NickName + "�� �������ϴ�.");
        changeRoomInfo();
    }

    public void changeRoomInfo()
    {
        string result = "������ �ο� ����Ʈ\n";

        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value.IsMasterClient)
            {
                result = result + "<color=red><b>(����) " + player.Value.NickName + "</b></color>";
            }
            else
            {
                result += player.Value.NickName;
            }
            
            result += "\n";
        }
        roomText.text = result;
    }

    public void startGame()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("PlayScene");
        }
        else
        {
            Debug.Log("���常 ������ �� �ֽ��ϴ�.");
        }
    }
}
