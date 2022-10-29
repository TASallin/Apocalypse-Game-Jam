using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPlatform : MonoBehaviour
{
    public bool isDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (isDown && transform.eulerAngles.z != 270) {
            float newZ = transform.eulerAngles.z - Time.deltaTime * 50f;
            if (newZ < 270) {
                newZ = 270;
            }
            transform.rotation = Quaternion.Euler(0, 0, newZ);
        } else if (!isDown && transform.eulerAngles.z > 0) {
            float newZ = System.Math.Min(transform.eulerAngles.z + Time.deltaTime * 50f, 360);
            transform.rotation = Quaternion.Euler(0, 0, newZ);
        }
    }

    public void PressLever() {
        isDown = !isDown;
    }
}
