using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDamage : MonoBehaviour
{
    public ToxicMeter toxicMeter;
    public int damage = 2;
    public float totalTime = 0;

    public int timeVariable = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        totalTime += Time.deltaTime;
        
        if (other.gameObject.tag == "Player") {
            if (totalTime > 1) {
                toxicMeter.InRain(damage);
                totalTime = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        totalTime += Time.deltaTime * timeVariable;
        
        if (other.gameObject.tag == "Player") {
            if (totalTime > 1) {
                toxicMeter.InRain(damage);
                totalTime = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        toxicMeter.OutOfRain(damage);
    }
}
