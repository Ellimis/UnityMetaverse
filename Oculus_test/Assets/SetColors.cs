using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColors : MonoBehaviour
{
    public DrawLine drawline;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Color")
        {
            drawline.SetLineMaterial(other.GetComponent<Renderer>().material);
        }
    }
}
