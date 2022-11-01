using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPurifier : MonoBehaviour
{

    public GameObject prompt;
    public Animator anim;
    public bool inRange;
    public AudioSource music;
    public AudioSource doomMusic;
    public GameObject noReturn;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update() {
        if (inRange && Input.GetKeyDown(KeyCode.E)) {
            anim.SetTrigger("Die");
            Game.instance.creditsFlag = true;
            prompt.SetActive(false);
            music.Pause();
            doomMusic.Play();
            noReturn.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!Game.instance.creditsFlag) {
            prompt.SetActive(true);
            inRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D other) {
        prompt.SetActive(false);
        inRange = false;
    }
}
