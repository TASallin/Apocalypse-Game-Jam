using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
    public GameObject platformOn;
    public GameObject platformOff;
    public GameObject prompt;
    public bool inRange;
    public Animator anim;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (inRange && Input.GetKeyDown(KeyCode.E)) {
            anim.SetTrigger("Press");
            if (platformOn.activeInHierarchy) {
                platformOn.SetActive(false);
                platformOff.SetActive(true);
            } else {
                platformOn.SetActive(true);
                platformOff.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        prompt.SetActive(true);
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        prompt.SetActive(false);
        inRange = false;
    }
}
