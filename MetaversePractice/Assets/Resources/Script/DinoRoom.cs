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
        Debug.Log("플레이어 " + newPlayer.NickName + " 입장.");
        changeRoomInfo();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("플레이어 " + otherPlayer.NickName + "이 나갔습니다.");
        changeRoomInfo();
    }

    public void changeRoomInfo()
    {
        string result = "접속한 인원 리스트\n";

        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value.IsMasterClient)
            {
                result = result + "<color=red><b>(방장) " + player.Value.NickName + "</b></color>";
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
            Debug.Log("방장만 시작할 수 있습니다.");
        }
    }
}
