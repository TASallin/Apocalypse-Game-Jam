using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
    public TiltingPlatform platform;
    public GameObject prompt;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {
        prompt.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other) {
        prompt.SetActive(false);
    }

    //see if the paper is collected when E is pressed
    void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKey(KeyCode.E)) {
            platform.PressLever();
        }
    }
}
