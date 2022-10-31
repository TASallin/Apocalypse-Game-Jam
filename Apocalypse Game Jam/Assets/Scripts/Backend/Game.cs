using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Game
{
    public static Game instance; //the singleton, call Game.instance to access everything in the game.
    public int level;
    public float waterLevel;
    [NonSerialized]
    public Checkpoint lastCheckpoint;
    public Collectibles collectibles;
    public float volume;
    [NonSerialized]
    public bool creditsFlag;

    public Game() {
        level = 1;
        waterLevel = -10;
        collectibles = new Collectibles();
        volume = 1f;
        creditsFlag = false;
    }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                       + Strings.fileName);
        bf.Serialize(file, this);
        file.Close();
    }
}
