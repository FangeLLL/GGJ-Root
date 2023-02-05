using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer soundMixer;
    public AudioMixer audioMixer;
    public float soundVolumeValue;
    public float audioVolumeValue;
    public Slider soundVolumeSlider;
    public Slider audioVolumeSlider;
    void Start()
    {
        soundVolumeSlider.value = PlayerPrefs.GetFloat("volumeValue", 0.75f);
        audioVolumeSlider.value = PlayerPrefs.GetFloat("audioValue", 0.75f);
    }

    public void SetSound(float volume)
    {
        soundMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volumeValue", volume);
    }

    public void SetAudio(float audio)
    {

        audioMixer.SetFloat("audio", Mathf.Log10(audio) * 20);
        PlayerPrefs.SetFloat("audioValue", audio);
    }
}

