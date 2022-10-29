using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Checkpoint : MonoBehaviour
{
    public Vector3 spawnPoint;
    public int level;
    public bool firstCheckpoint;

    void Start() {
        if (firstCheckpoint) {
            if (Game.instance == null) {
                Game.instance = new Game();
            }
            Game.instance.lastCheckpoint = this;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        Game.instance.lastCheckpoint = this;
    }
}
