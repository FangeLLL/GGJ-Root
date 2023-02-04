using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpilSwingsSword : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    //public GameObject PauseMenu;
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    /*void Update()
    {
        if (PauseMenu.GetComponent<PauseMenu>().gameIsPaused == false)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }*/

    public void SerpilSwordSwinging()
    {
        source.clip = sounds[Random.Range(0, 2)];
        source.PlayOneShot(source.clip);
    }
    public void SerpilDash()
    {
        source.clip = sounds[2];
        source.PlayOneShot(source.clip);
    }

    public void SerpilDeath()
    {
        source.clip = sounds[Random.Range(3, 5)];
        source.PlayOneShot(source.clip);
    }

    public void Deathblow()
    {
        source.clip = sounds[5];
        source.PlayOneShot(source.clip);
    }
}
