using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour
{
    public Transform target = null;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(target)
        {
            this.transform.position = getPos(target.position);
        }
    }

    public void startBubble(Transform target, string message)
    {
        this.target = target;
        this.transform.GetChild(0).GetComponent<Text>().text = message;
        Destroy(gameObject, 3.0f);
    }

    public Vector3 getPos(Vector3 targetPos)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(targetPos);
        Vector3 newVector = new Vector3(screenPos.x, (screenPos.y + 100));
        return newVector;
    }
}
