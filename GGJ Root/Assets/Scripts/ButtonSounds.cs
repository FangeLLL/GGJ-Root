using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    public GameObject settingsMenu;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void ButtonClickEnter()
    {
        source.clip = sounds[0];
        source.PlayOneShot(source.clip);
    }
    public void ButtonClickExit()
    {
        source.clip = sounds[1];
        source.PlayOneShot(source.clip);
    }
}
