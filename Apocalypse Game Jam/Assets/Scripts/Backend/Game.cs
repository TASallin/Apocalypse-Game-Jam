using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Game
{
    public static Game instance; //the singleton, call Game.instance to access everything in the game.
    public int level;
    public float waterLevel;
    public Checkpoint lastCheckpoint;
    public Collectibles collectibles;

    public Game() {
        level = 1;
        waterLevel = -2;
        collectibles = new Collectibles();
    }
}
