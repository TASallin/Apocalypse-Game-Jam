using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour
{
    public Image fadeToBlack;
    private bool activated;
    public string nextScene;
    public AudioSource music;
    public AudioSource victorySound;
    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        countdown = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated) {
            float alpha = System.Math.Min(fadeToBlack.color.a + Time.deltaTime * 0.5f, 1);
            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, alpha);
            music.volume = 1f - 2f * alpha;
            countdown -= Time.deltaTime;
            if (countdown <= 0) {
                Game.instance.level += 1;
                Game.instance.Save();
                SceneManager.LoadScene(nextScene);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        fadeToBlack.gameObject.SetActive(true);
        activated = true;
        victorySound.Play();
    }
}
