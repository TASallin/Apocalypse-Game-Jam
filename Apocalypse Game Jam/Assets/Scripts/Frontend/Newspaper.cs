using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {
    public int index;
    public GameObject prompt;

    // Start is called before the first frame update
    void Start() {
        if (Game.instance == null || !Game.instance.collectibles.papers[index]) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);//if the paper is already collected
        }
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
            Game.instance.collectibles.papers[index] = true;
            Game.instance.Save();
            gameObject.SetActive(false);
        }
    }
}
