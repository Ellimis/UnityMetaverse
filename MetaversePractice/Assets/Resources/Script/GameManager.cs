using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject dinoPrefab;
    public GameObject bubble;
    //private Vector2 pos = Vector2.zero;
    //private int curPlayerNum = 0;

    // -4.5 < x < 0.5
    // -9 < 2x < 1
    // -3 < y  < 2

    private void Awake()
    {
        //Debug.Log(PlayerPrefs.GetInt("PlayerCount"));
        //Debug.Log(PlayerPrefs.GetInt("PlayerCount").GetType());

        /*
        if(PlayerPrefs.GetInt("PlayerCount") == 0)
        {
            int temp = PlayerPrefs.GetInt("PlayerCount") + 1;
            PlayerPrefs.SetInt("PlayerCount", temp);
            curPlayerNum = temp;
        }
        else
        {
            int temp = PlayerPrefs.GetInt("PlayerCount") + 1;
            PlayerPrefs.SetInt("PlayerCount", temp);
            curPlayerNum = temp;
        }
        */
        //int temp = PlayerPrefs.GetInt("PlayerCount") + 1;
        //PlayerPrefs.SetInt("PlayerCount", temp);
        //curPlayerNum = temp;

        
    }

    void Start()
    {
        PhotonNetwork.Instantiate("Prefab/"+dinoPrefab.name, Vector2.zero, Quaternion.identity, 0);
        //Debug.Log("I am " + curPlayerNum + "th player and my name is " + PhotonNetwork.NickName);

    }

    void Update()
    {

    }

    public void sendChat(InputField obj)
    {
        if (obj.text.Equals(string.Empty)) return;

        string[] infos = new string[2];
        infos[0] = PhotonNetwork.NickName;
        infos[1] = obj.text;
        photonView.RPC("receiveChat", RpcTarget.AllBuffered, infos);
    }

    [PunRPC]
    void receiveChat(string[] infos)
    {
        string senderNickname = infos[0];
        string data = infos[1];
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject player in players)
        {
            if(player.GetComponent<PhotonView>().Owner.NickName.Equals(senderNickname))
            {
                GameObject newBubble = Instantiate(bubble, GameObject.Find("Canvas").transform);
                newBubble.GetComponent<BubbleManager>().startBubble(player.transform, data);
                break;
            }
        }
    }
}
