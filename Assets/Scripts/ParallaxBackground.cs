using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform pc;
    public float parallax = 0.5f;

    private float lastPosX;

    void Start()
    {
        lastPosX = pc.position.x;
    }

    void Update()
    {
        float diff = pc.position.x - lastPosX;
        transform.position += new Vector3(diff * parallax, 0f, 0f);

        lastPosX = pc.position.x;
    }
}
