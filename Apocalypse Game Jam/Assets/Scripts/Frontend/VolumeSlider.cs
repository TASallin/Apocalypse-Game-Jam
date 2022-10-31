using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    public AudioMixer mixer;
    public Slider slider;
    public string paramName = "Volume";

    void Start() {
        slider.value = PlayerPrefs.GetFloat(paramName, 0.75f);
    }

    public void SetLevel(float sliderValue) {
        mixer.SetFloat(paramName, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(paramName, sliderValue);
    }
}