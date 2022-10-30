using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicMeter : MonoBehaviour
{
    public int toxic;
    public int defaultToxic = 0;
    public int toxicThreshold = 15;
    public GameObject ToxicLvl1;
    public GameObject ToxicLvl2;
    public GameObject ToxicLvl3;

    // Start is called before the first frame update
    void Start()
    {
        toxic = defaultToxic;
        ToxicLvl1.gameObject.SetActive(false);
        ToxicLvl2.gameObject.SetActive(false);
        ToxicLvl3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InRain(int amount) {
        toxic += amount;

        if (toxic >= toxicThreshold / 4) {
            ToxicLvl1.gameObject.SetActive(true);
            ToxicLvl2.gameObject.SetActive(false);
            ToxicLvl3.gameObject.SetActive(false);
        }

        if (toxic >= toxicThreshold / 3) {
            ToxicLvl1.gameObject.SetActive(false);
            ToxicLvl2.gameObject.SetActive(true);
            ToxicLvl3.gameObject.SetActive(false);
        }

        if (toxic >= toxicThreshold / 2) {
            ToxicLvl1.gameObject.SetActive(false);
            ToxicLvl2.gameObject.SetActive(false);
            ToxicLvl3.gameObject.SetActive(true);
        }

        if (toxic >= toxicThreshold) {
            Destroy(gameObject);
        }
    }

    public void OutOfRain (int amount) {
        toxic -= amount;

        if (toxic <= toxicThreshold / 4) {
            ToxicLvl1.gameObject.SetActive(true);
            ToxicLvl2.gameObject.SetActive(false);
            ToxicLvl3.gameObject.SetActive(false);
        }

        if (toxic <= toxicThreshold / 3) {
            ToxicLvl1.gameObject.SetActive(false);
            ToxicLvl2.gameObject.SetActive(true);
            ToxicLvl3.gameObject.SetActive(false);
        }

        if (toxic <= toxicThreshold / 2) {
            ToxicLvl1.gameObject.SetActive(false);
            ToxicLvl2.gameObject.SetActive(false);
            ToxicLvl3.gameObject.SetActive(true);
        }
    }
}
