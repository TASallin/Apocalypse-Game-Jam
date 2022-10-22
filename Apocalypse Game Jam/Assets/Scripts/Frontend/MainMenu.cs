using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //is called when the new game button is pressed in the main menu
    public void NewGame() {
        Game.instance = new Game();
    }

    //is called when the continue button is pressed in the main menu
    public void Continue() {
        if (File.Exists(Application.persistentDataPath
                   + Strings.fileName)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + Strings.fileName, FileMode.Open);
            try {
                Game.instance = (Game)bf.Deserialize(file);
                file.Close();
            } catch (Exception e) {
                file.Close();
                File.Delete(Application.persistentDataPath
                       + Strings.fileName);
                NewGame();
            }
        } else {
            NewGame();
        }
    }

    //is called when the exit to desktop button is pressed in the main menu
    public void Exit() {
        Application.Quit();
    }
}
