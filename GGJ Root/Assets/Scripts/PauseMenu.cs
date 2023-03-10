using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public bool pauseMenu = false;
    public bool deactive = false;
    public GameObject pauseMenuUI;
    public Animator animator;

    private int mainMenu;
    GameObject a;

    void OnEnable()
    {
        pauseMenu = false;
        deactive = false;
    }

    void Start()
    {
        pauseMenu = false;
        StartCoroutine(DeactivePauseOnStart());

    }

    void Update()
    {
        if (deactive == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu = true;
                if (pauseMenu == true)
                {
                    if (gameIsPaused)
                    {
                        Resume();
                    }
                    else
                    {
                        Pause();
                    }
                }
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseMenu = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = true;
        //GameObject.FindGameObjectWithTag("Katana").GetComponent<KatanaFunction>().enabled = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        pauseMenu = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = false;
        //GameObject.FindGameObjectWithTag("Katana").GetComponent<KatanaFunction>().enabled = false;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        StartCoroutine(ExitGame());
    }

    public IEnumerator ExitGame()
    {
        a = GameObject.Find("PauseMenu");
        a.SetActive(false);
        deactive = true;
        animator = GameObject.Find("LevelChanger").GetComponent<LevelChanger>().animator;
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }

    public IEnumerator DeactivePauseOnStart()
    {
        deactive = true;
        yield return new WaitForSeconds(1f);
        deactive = false;
    }
}
