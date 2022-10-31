using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{

    public AudioSource doomMusic;
    public AudioSource creditsMusic;
    public Image image;
    public GameObject noReturn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = System.Math.Min(image.color.a + Time.deltaTime * 0.5f, 1);
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    void OnEnable() {
        creditsMusic.Play();
        noReturn.SetActive(false);
    }
}
