using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunRandomizerTemp : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    //public GameObject pauseMenu;
    void Start()
    {
        source = GetComponent<AudioSource>();
        //pauseMenu = GameObject.Find("PauseMenuManager");
    }

    void Update()
    {
        /*if (pauseMenu.GetComponent<PauseMenu>().gameIsPaused == false)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }*/
    }

    public void SerpilKillsGunEnemy()
    {
        source.clip = sounds[Random.Range(0, 6)];
        source.PlayOneShot(source.clip);
    }

    public void SerpilHitEnemy2()
    {
        source.clip = sounds[Random.Range(6, 14)];
        source.PlayOneShot(source.clip);
    }


}
