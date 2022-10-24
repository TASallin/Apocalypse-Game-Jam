using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public float duration;
    float countdown;
    bool isStanding;

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
                gameObject.SetActive(false); //placeholder until animation/etc is decided
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        isStanding = true;
    }

    void OnCollisionExit2D(Collision2D other) {
        isStanding = false;
    }

}
