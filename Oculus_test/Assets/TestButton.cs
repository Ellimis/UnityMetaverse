using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    public GameObject[] objects;

    public void CreateObject(int idx)
    {
        Vector3 pos = new Vector3(Random.Range(-3, 3), Random.Range(0, 2), Random.Range(0, 3));

        Instantiate(objects[idx], pos, Quaternion.identity);
    }
}
