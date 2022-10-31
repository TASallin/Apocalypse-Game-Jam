using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public float duration;
    float countdown;
    bool isStanding;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        countdown = duration;
        isStanding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStanding) {
            countdown -= Time.deltaTime;
            if (countdown <= 0) {
                anim.SetTrigger("Break");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player" && other.transform.position.y > transform.position.y + 0.6f) {
            isStanding = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            isStanding = false;
        }
    }

    public void Broken() {
        gameObject.SetActive(false);
    }

}
