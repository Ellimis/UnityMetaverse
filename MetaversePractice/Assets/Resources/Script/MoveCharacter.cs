using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveCharacter : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode moveRight = KeyCode.RightArrow;
    public float speed = 5;
    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true) return;

        float moveX = 0;
        float moveY = 0;
        if (Input.GetKey(moveUp) || Input.GetKey(KeyCode.W)) moveY += speed;
        if (Input.GetKey(moveDown) || Input.GetKey(KeyCode.S) ) moveY -= speed;
        if (Input.GetKey(moveLeft) || Input.GetKey(KeyCode.A)) moveX -= speed;
        if (Input.GetKey(moveRight) || Input.GetKey(KeyCode.D)) moveX += speed;
        Vector2 moveVector = new Vector2(moveX, moveY);
        rigidBody2D.AddForce(moveVector);
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        transform.GetChild(0).GetComponent<TextMesh>().text = info.Sender.NickName;

        if(photonView.IsMine == false)
        {
            Destroy(GetComponent<EventManager>());
            Destroy(GetComponent<AnimatorManager>());
        }
        else
        {
            Camera.main.transform.parent = gameObject.transform;
            Camera.main.transform.localPosition = new Vector3(0, 0, -10f);
        }
    }
}
