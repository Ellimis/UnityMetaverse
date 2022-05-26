using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{

    public OVRInput.Controller controller;

    [Header("Button One")]
    public UnityEngine.Events.UnityEvent OnClick_ButtonOne;
    public UnityEngine.Events.UnityEvent OnClickDown_ButtonOne;

    [Header("Button Two")]
    public UnityEngine.Events.UnityEvent OnClick_ButtonTwo;
    public UnityEngine.Events.UnityEvent OnClickDown_ButtonTwo;

    [Header("Button Trigger")]
    public UnityEngine.Events.UnityEvent OnClick_ButtonTrigger;
    public UnityEngine.Events.UnityEvent OnClickDown_ButtonTrigger;
    public UnityEngine.Events.UnityEvent OnClickUp_ButtonTrigger;

    [Header("Button Grab")]
    public UnityEngine.Events.UnityEvent OnClick_ButtonGrab;
    public UnityEngine.Events.UnityEvent OnClickDown_ButtonGrab;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (OVRInput.GetDown(OVRInput.Button.One, controller))
        {
            OnClickDown_ButtonOne.Invoke();
        }
        else if (OVRInput.Get(OVRInput.Button.One, controller))
        {
            OnClick_ButtonOne.Invoke();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two, controller))
        {
            OnClickDown_ButtonTwo.Invoke();
        }
        else if (OVRInput.Get(OVRInput.Button.Two, controller))
        {
            OnClick_ButtonTwo.Invoke();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            OnClickDown_ButtonTrigger.Invoke();
        }
        else if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            OnClickUp_ButtonTrigger.Invoke();
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            OnClick_ButtonTrigger.Invoke();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            OnClickDown_ButtonGrab.Invoke();
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            OnClick_ButtonGrab.Invoke();
        }

    }


}
