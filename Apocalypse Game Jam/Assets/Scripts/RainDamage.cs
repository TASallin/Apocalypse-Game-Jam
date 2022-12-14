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
        Invoke("Heal", 10.0f);
    }

    void Heal() {
        for (int i = 0; i < toxicMeter.toxic + damage; i++) {
            toxicMeter.toxic -= damage;

            if (toxicMeter.toxic <= 0) {
                toxicMeter.ToxicLvl1.gameObject.SetActive(false);
                toxicMeter.ToxicLvl2.gameObject.SetActive(false);
                toxicMeter.ToxicLvl3.gameObject.SetActive(false);
                break;
            }
        }
    }
}
