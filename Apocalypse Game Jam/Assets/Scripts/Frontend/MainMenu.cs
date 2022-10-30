using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;

    // Start is called before the first frame update
    void Start() {
        if (File.Exists(Application.persistentDataPath
                    + Strings.fileName)) {
            continueButton.interactable = true;
        } else {
            continueButton.interactable = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    //is called when the new game button is pressed in the main menu
    public void NewGame() {
        Game.instance = new Game();
        EnterLevel();
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
                EnterLevel();
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

    public void EnterLevel() {
        if (Game.instance.level == 3) {
            SceneManager.LoadScene("Level3");
        } else if (Game.instance.level == 2) {
            SceneManager.LoadScene("Level2");
        } else {
            SceneManager.LoadScene("Level1");
        }
    }
}
