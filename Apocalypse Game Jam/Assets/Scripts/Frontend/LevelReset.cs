using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    public List<GameObject> breakingPlatforms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset() {
        foreach (GameObject g in breakingPlatforms) {
            g.SetActive(true);
        }
    }
}
