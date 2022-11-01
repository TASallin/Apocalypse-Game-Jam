using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretTunnel : MonoBehaviour
{

    public Transform player;
    public GameObject cover;
    public float left;
    public float right;
    public float up;
    public float down;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool inBox = InBounds();
        if (inBox && cover.activeSelf) {
            cover.SetActive(false);
        } else if (!inBox && !cover.activeSelf) {
            cover.SetActive(true);
        }
    }

    public bool InBounds() {
        return player.position.x > left && player.position.x < right && player.position.y < up && player.position.y > down;
    }
}
