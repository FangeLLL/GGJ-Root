using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSoundRandomizer : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    //public GameObject PauseMenu;
    void Start()
    {
        source = GetComponent<AudioSource>();
        //PauseMenu = GameObject.Find("PauseMenuManager");
    }

    void Update()
    {
        /*if (PauseMenu.GetComponent<PauseMenu>().gameIsPaused == false)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }*/
    }

    public void SerpilKillsEnemy()
    {
        source.clip = sounds[Random.Range(0, 6)];
        source.PlayOneShot(source.clip);
    }

    public void SerpilHitEnemy()
    {
        source.clip = sounds[Random.Range(8, 16)];
        source.PlayOneShot(source.clip);
    }

    public void EnemySwordSwing()
    {
        source.clip = sounds[Random.Range(6, 8)];
        source.PlayOneShot(source.clip);
    }

    /*public void CallEnemyIEnumerator()
    {
        StartCoroutine(EnemySwordSwing());
    }

    public IEnumerator EnemySwordSwing()
    {
        yield return new WaitForSeconds(.5f);
        source.clip = sounds[Random.Range(12, 14)];
        source.PlayOneShot(source.clip);
    }
    public void stopcorputines()
    {
        StopAllCoroutines();
    }*/
}
