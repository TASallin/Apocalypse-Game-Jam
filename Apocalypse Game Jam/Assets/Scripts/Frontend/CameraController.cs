using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float leftBound;
    public float rightBound;
    public float topBound;
    public float bottomBound;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.position.x;
        float y = player.position.y;
        x = System.Math.Max(leftBound, System.Math.Min(x, rightBound));
        y = System.Math.Max(bottomBound, System.Math.Min(y, topBound));
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
