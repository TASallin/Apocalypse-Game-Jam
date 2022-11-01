using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    public List<GameObject> breakingPlatforms;
    public List<float> countdowns;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < countdowns.Count; i++) {
            countdowns[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < breakingPlatforms.Count; i++) {
            if (!breakingPlatforms[i].activeSelf) {
                if (countdowns[i] < 0) {
                    countdowns[i] = 5f;
                } else {
                    countdowns[i] -= Time.deltaTime;
                    if (countdowns[i] <= 0) {
                        countdowns[i] = -1;
                        breakingPlatforms[i].SetActive(true);
                    }
                }
            }
        }
    }

    public void Reset() {
        foreach (GameObject g in breakingPlatforms) {
            g.SetActive(true);
        }
        for (int i = 0; i < countdowns.Count; i++) {
            countdowns[i] = -1;
        }
    }
}
