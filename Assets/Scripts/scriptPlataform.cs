using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlataforma : MonoBehaviour
{
    private Vector2 posIni;
    public float desloc = 0.5f;
    private float cont = 0;
    public float h = 5;
    public float w = 35;
    void Start()
    {
        posIni = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin(cont) * w;
        float y = Mathf.Cos(cont) * h;

        transform.position = new Vector2(posIni.x + x, posIni.y + y);

        cont = cont + desloc * Time.deltaTime;

        if (cont > 2 * Mathf.PI)
            cont = cont - 2 * Mathf.PI;
    }
}
