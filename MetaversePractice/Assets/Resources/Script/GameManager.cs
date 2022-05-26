using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject dinoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("Prefab/"+dinoPrefab.name, Vector2.zero, Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
