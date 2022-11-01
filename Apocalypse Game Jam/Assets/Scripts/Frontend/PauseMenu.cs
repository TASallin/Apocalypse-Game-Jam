using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject pauseButton;
    public List<Image> newspapers;
    public Image mainPaper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseButton.activeSelf) {
                Pause();
            } else {
                Resume();
            }
        }
    }

    public void Pause() {
        menu.SetActive(true);
        pauseButton.SetActive(false);
        for (int i = 0; i < newspapers.Count; i++) {
            if (Game.instance.collectibles.papers[i]) {
                newspapers[i].gameObject.SetActive(true);
            } else {
                newspapers[i].gameObject.SetActive(false);
            }
        }
        Time.timeScale = 0f;
    }

    public void Resume() {
        menu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ToMainMenu() {
        Time.timeScale = 1f;
        Game.instance.Save();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame() {
        Time.timeScale = 1f;
        Game.instance.Save();
        Application.Quit();
    }

    public void PaperButton(int index) {
        mainPaper.sprite = newspapers[index].sprite;
    }

}
