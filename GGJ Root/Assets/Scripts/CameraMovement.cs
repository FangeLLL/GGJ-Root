using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public FamilyTreeStatInformer familyTreeStatInformer;
    public GameObject canvas2;
    public Transform Parent;
    public Transform Child;
    public GameObject PhotoFrame1;
    public GameObject PhotoFrame2;
    public GameObject PhotoFrame3;
    public GameObject PhotoFrame4;
    public GameObject PhotoFrame5;
    public GameObject PhotoFrame6;
    public GameObject SerpilRootoglu1;
    public GameObject SerpilRootoglu2;
    public GameObject SerpilRootoglu3;
    public GameObject SerpilRootoglu4;
    public GameObject SerpilRootoglu5;
    public GameObject SerpilRootoglu6;
    Vector3 deathpositiontracker;
    public float moveSpeed = 2f;
    public float DeathCounterforChildParrentSet;
    public bool moveCamera = false;
    public bool setpositiontoparent = false;
    private bool setpositiontochild = false;
    private bool b = true;
    public Image fadeImage;
    [SerializeField] CinemachineVirtualCamera vcam;

    private void Start()
    {
        canvas2.SetActive(true);
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (moveCamera)
        {
            transform.position = Vector3.Lerp(transform.position, Child.position, moveSpeed * Time.deltaTime);
            vcam.m_Follow = this.transform;
            if (Vector3.Distance(transform.position, Child.position) <= 0.2f)
            {
                if (b)
                {
                    StartCoroutine(CameraSlideDone());
                    b = false;
                }
            }
        }
        if (setpositiontoparent)
        {
            vcam.m_Follow = Parent.transform;
        }
        if (setpositiontochild)
        {
            if (DeathCounterforChildParrentSet == 1)
            {
                vcam.m_Follow = SerpilRootoglu2.transform;
            }

            else if (DeathCounterforChildParrentSet == 2)
            {
                vcam.m_Follow = SerpilRootoglu3.transform;
            }

            else if (DeathCounterforChildParrentSet == 3)
            {
                vcam.m_Follow = SerpilRootoglu4.transform;
            }

            else if (DeathCounterforChildParrentSet == 4)
            {
                vcam.m_Follow = SerpilRootoglu5.transform;
            }

            else if (DeathCounterforChildParrentSet == 5)
            {
                vcam.m_Follow = SerpilRootoglu6.transform;
            }
        }
    }

    public IEnumerator CameraSlideDone()
    {
        //Child to player

        if (DeathCounterforChildParrentSet == 1)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(0.25f);
            SerpilRootoglu2.transform.position = deathpositiontracker;
            SerpilRootoglu2.GetComponent<PlayerMovement>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            setpositiontochild = true;
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeIn());
            yield return new WaitForSeconds(.25f);
            //familyTreeStatInformer.OnPlayerDeath();
            yield return new WaitForSeconds(.25f);
            moveCamera = false;
        }

        else if (DeathCounterforChildParrentSet == 2)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(0.25f);
            SerpilRootoglu3.transform.position = deathpositiontracker;
            SerpilRootoglu3.GetComponent<PlayerMovement>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            setpositiontochild = true;
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeIn());
            yield return new WaitForSeconds(.25f);
            //familyTreeStatInformer.OnPlayerDeath();
            yield return new WaitForSeconds(.25f);
            moveCamera = false;
        }

        else if (DeathCounterforChildParrentSet == 3)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(0.25f);
            SerpilRootoglu4.transform.position = deathpositiontracker;
            SerpilRootoglu4.GetComponent<PlayerMovement>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            setpositiontochild = true;
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeIn());
            yield return new WaitForSeconds(.25f);
            //familyTreeStatInformer.OnPlayerDeath();
            yield return new WaitForSeconds(.25f);
            moveCamera = false;
        }

        else if (DeathCounterforChildParrentSet == 4)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(0.25f);
            SerpilRootoglu5.transform.position = deathpositiontracker;
            SerpilRootoglu5.GetComponent<PlayerMovement>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            setpositiontochild = true;
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeIn());
            yield return new WaitForSeconds(.25f);
            //familyTreeStatInformer.OnPlayerDeath();
            yield return new WaitForSeconds(.25f);
            moveCamera = false;
        }

        else if (DeathCounterforChildParrentSet == 5)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(0.25f);
            SerpilRootoglu6.transform.position = deathpositiontracker;
            SerpilRootoglu6.GetComponent<PlayerMovement>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            setpositiontochild = true;
            yield return new WaitForSeconds(1f);
            StartCoroutine(FadeIn());
            yield return new WaitForSeconds(.25f);
            //familyTreeStatInformer.OnPlayerDeath();
            yield return new WaitForSeconds(.25f);
            moveCamera = false;
        }
    }


    public IEnumerator ManFuckThisGame()
    {
        DeathCounterforChildParrentSet++;

        setpositiontochild = false;
        b = true;

        if (DeathCounterforChildParrentSet == 1)
        {

            SerpilRootoglu1.GetComponent<PlayerMovement>().enabled = false;
            SerpilRootoglu1.GetComponent<PlayerKiller>().enabled = false;

            StartCoroutine(FadeOut());

            yield return new WaitForSeconds(0.25f);

            deathpositiontracker = SerpilRootoglu1.transform.position;
            Parent = PhotoFrame1.transform;
            transform.position = Parent.position;
            SerpilRootoglu1.transform.position = new Vector3(PhotoFrame1.transform.position.x, PhotoFrame1.transform.position.y, -5f);
            Child = PhotoFrame2.transform;
            SerpilRootoglu2.transform.position = new Vector3(PhotoFrame2.transform.position.x, PhotoFrame2.transform.position.y, -5f);
            PhotoFrame2.SetActive(true);
            SerpilRootoglu2.SetActive(true);
            SerpilRootoglu2.GetComponent<PlayerMovement>().enabled = false;


            yield return new WaitForSeconds(0.25f);

            setpositiontoparent = true;

            yield return new WaitForSeconds(1f);

            StartCoroutine(FadeIn());

            yield return new WaitForSeconds(.25f);

            familyTreeStatInformer.OnPlayerDeath();

            //yield return new WaitForSeconds(3.75f);

            //moveCamera = true;
            //setpositiontoparent = false;

            //yield return null;
        }

        else if (DeathCounterforChildParrentSet == 2)
        {
            SerpilRootoglu2.GetComponent<PlayerMovement>().enabled = false;
            SerpilRootoglu2.GetComponent<PlayerKiller>().enabled = false;

            StartCoroutine(FadeOut());

            yield return new WaitForSeconds(0.25f);

            deathpositiontracker = SerpilRootoglu2.transform.position;
            Parent = PhotoFrame2.transform;
            transform.position = Parent.position;
            SerpilRootoglu2.transform.position = new Vector3(PhotoFrame2.transform.position.x, PhotoFrame2.transform.position.y, -5f);
            Child = PhotoFrame3.transform;
            SerpilRootoglu3.transform.position = new Vector3(PhotoFrame3.transform.position.x, PhotoFrame3.transform.position.y, -5f);
            PhotoFrame3.SetActive(true);
            SerpilRootoglu3.SetActive(true);
            SerpilRootoglu3.GetComponent<PlayerMovement>().enabled = false;


            yield return new WaitForSeconds(0.25f);

            setpositiontoparent = true;

            yield return new WaitForSeconds(1f);

            StartCoroutine(FadeIn());

            yield return new WaitForSeconds(.25f);

            familyTreeStatInformer.OnPlayerDeath();

            yield return new WaitForSeconds(3.75f);

            moveCamera = true;
            setpositiontoparent = false;

            yield return null;
        }

        else if (DeathCounterforChildParrentSet == 3)
        {
            SerpilRootoglu3.GetComponent<PlayerMovement>().enabled = false;
            SerpilRootoglu3.GetComponent<PlayerKiller>().enabled = false;

            StartCoroutine(FadeOut());

            yield return new WaitForSeconds(0.25f);

            deathpositiontracker = SerpilRootoglu3.transform.position;
            Parent = PhotoFrame3.transform;
            transform.position = Parent.position;
            SerpilRootoglu3.transform.position = new Vector3(PhotoFrame3.transform.position.x, PhotoFrame3.transform.position.y, -5f);
            Child = PhotoFrame4.transform;
            SerpilRootoglu4.transform.position = new Vector3(PhotoFrame4.transform.position.x, PhotoFrame4.transform.position.y, -5f);
            PhotoFrame4.SetActive(true);
            SerpilRootoglu4.SetActive(true);
            SerpilRootoglu4.GetComponent<PlayerMovement>().enabled = false;


            yield return new WaitForSeconds(0.25f);

            setpositiontoparent = true;

            yield return new WaitForSeconds(1f);

            StartCoroutine(FadeIn());

            yield return new WaitForSeconds(.25f);

            familyTreeStatInformer.OnPlayerDeath();

            yield return new WaitForSeconds(3.75f);

            moveCamera = true;
            setpositiontoparent = false;

            yield return null;
        }

        else if (DeathCounterforChildParrentSet == 4)
        {
            SerpilRootoglu4.GetComponent<PlayerMovement>().enabled = false;
            SerpilRootoglu4.GetComponent<PlayerKiller>().enabled = false;

            StartCoroutine(FadeOut());

            yield return new WaitForSeconds(0.25f);

            deathpositiontracker = SerpilRootoglu4.transform.position;
            Parent = PhotoFrame4.transform;
            transform.position = Parent.position;
            SerpilRootoglu4.transform.position = new Vector3(PhotoFrame4.transform.position.x, PhotoFrame4.transform.position.y, -5f);
            Child = PhotoFrame5.transform;
            SerpilRootoglu5.transform.position = new Vector3(PhotoFrame5.transform.position.x, PhotoFrame5.transform.position.y, -5f);
            PhotoFrame5.SetActive(true);
            SerpilRootoglu5.SetActive(true);
            SerpilRootoglu5.GetComponent<PlayerMovement>().enabled = false;


            yield return new WaitForSeconds(0.25f);

            setpositiontoparent = true;

            yield return new WaitForSeconds(1f);

            StartCoroutine(FadeIn());

            yield return new WaitForSeconds(.25f);

            familyTreeStatInformer.OnPlayerDeath();

            yield return new WaitForSeconds(3.75f);

            moveCamera = true;
            setpositiontoparent = false;

            yield return null;
        }

        else if (DeathCounterforChildParrentSet == 5)
        {
            SerpilRootoglu5.GetComponent<PlayerMovement>().enabled = false;
            SerpilRootoglu5.GetComponent<PlayerKiller>().enabled = false;

            StartCoroutine(FadeOut());

            yield return new WaitForSeconds(0.25f);

            deathpositiontracker = SerpilRootoglu5.transform.position;
            Parent = PhotoFrame5.transform;
            transform.position = Parent.position;
            SerpilRootoglu5.transform.position = new Vector3(PhotoFrame5.transform.position.x, PhotoFrame5.transform.position.y, -5f);
            Child = PhotoFrame6.transform;
            SerpilRootoglu6.transform.position = new Vector3(PhotoFrame6.transform.position.x, PhotoFrame6.transform.position.y, -5f);
            PhotoFrame6.SetActive(true);
            SerpilRootoglu6.SetActive(true);
            SerpilRootoglu6.GetComponent<PlayerMovement>().enabled = false;


            yield return new WaitForSeconds(0.25f);

            setpositiontoparent = true;

            yield return new WaitForSeconds(1f);

            StartCoroutine(FadeIn());

            yield return new WaitForSeconds(.25f);

            familyTreeStatInformer.OnPlayerDeath();

            yield return new WaitForSeconds(3.75f);

            moveCamera = true;
            setpositiontoparent = false;

            yield return null;
        }

        else
        {
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    private IEnumerator FadeOut()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime / 0.25f;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / 0.25f;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
