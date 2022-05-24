using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.Space;
    private GameObject nearestTarget = null;
    private float nearestDistance = 99999;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(interactionKey) || Input.GetMouseButtonDown(0))
        {
            if (!nearestTarget) return;
            if (!nearestTarget.GetComponent<Interactable>()) return;

            string result = nearestTarget.GetComponent<Interactable>().interactResult;
            if ((result.Length >= 4) && (result.Substring(0, 4).ToLower().Equals("http"))) Application.OpenURL(result);
            else Debug.Log(nearestTarget.GetComponent<Interactable>().interactResult);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("Object")) return;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("Object")) return;
        float currentDistance = Vector2.Distance(this.transform.position, target.transform.position);
        if(currentDistance < nearestDistance)
        {
            if(target != nearestTarget)
            {
                if (nearestTarget != null) nearestTarget.GetComponent<SpriteRenderer>().color = Color.white;
                target.GetComponent<SpriteRenderer>().color = Color.red;
            }
            nearestTarget = target;
            nearestDistance = currentDistance;
        }
        if (nearestTarget == target) nearestDistance = currentDistance;
        else return;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("Object")) return;
        if(target == nearestTarget)
        {
            target.GetComponent<SpriteRenderer>().color = Color.white;
            nearestTarget = null;
            nearestDistance = 99999;
        }
    }
}
