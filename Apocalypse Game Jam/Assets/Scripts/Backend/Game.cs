using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Game
{
    public static Game instance; //the singleton, call Game.instance to access everything in the game.
    public int level;
    public float waterLevel;
}
