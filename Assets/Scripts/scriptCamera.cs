using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public GameObject Pc;
    public float offsetY = 2;
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(Pc.transform.position.x, Pc.transform.position.y + offsetY, -10);
    }
}
