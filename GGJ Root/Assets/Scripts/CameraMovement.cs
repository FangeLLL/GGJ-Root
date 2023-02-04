using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
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
    public float moveSpeed = 2f;
    private bool moveCamera = false;
    private bool setpositiontoparent = false;
    private bool a = false;
    private bool b = true;
    public GameObject canvas2;
    public Image fadeImage;
    private float DeathCounterforChildParrentSet;
    [SerializeField] CinemachineVirtualCamera vcam;



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
        if (a)
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
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(.5f);
        moveCamera = false;
        NextChildSetter();
        a = true;
    }

    public IEnumerator MoveCameraOnPlayerDeath()
    {
        transform.position = Parent.position;
        canvas2.SetActive(true);

        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(0.5f);
        setpositiontoparent = true;
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(3f);
        moveCamera = true;
        setpositiontoparent = false;
        yield return null;
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

    public void Parent_ChildSetter()
    {
        DeathCounterforChildParrentSet++;
        a = false;
        b = true;

        if (DeathCounterforChildParrentSet == 1)
        {
            Parent = PhotoFrame1.transform;
            Child = PhotoFrame2.transform;
            PhotoFrame2.SetActive(true);
        }

        else if (DeathCounterforChildParrentSet == 2)
        {
            Parent = PhotoFrame2.transform;
            Child = PhotoFrame3.transform;
            PhotoFrame3.SetActive(true);
        }

        else if (DeathCounterforChildParrentSet == 3)
        {
            Parent = PhotoFrame3.transform;
            Child = PhotoFrame4.transform;
            PhotoFrame4.SetActive(true);
        }

        else if (DeathCounterforChildParrentSet == 4)
        {
            Parent = PhotoFrame4.transform;
            Child = PhotoFrame5.transform;
            PhotoFrame5.SetActive(true);
        }

        else if (DeathCounterforChildParrentSet == 5)
        {
            Parent = PhotoFrame5.transform;
            Child = PhotoFrame6.transform;
            PhotoFrame6.SetActive(true);
        }

        //else restart scene game over
    }

    public void NextChildSetter()
    {
        if (DeathCounterforChildParrentSet == 1)
        {
            SerpilRootoglu1.SetActive(false);
            SerpilRootoglu2.SetActive(true);
        }

        else if (DeathCounterforChildParrentSet == 2)
        {
            SerpilRootoglu2.SetActive(false);
            SerpilRootoglu3.SetActive(true);
        }

        else if (DeathCounterforChildParrentSet == 3)
        {
            SerpilRootoglu3.SetActive(false);
            SerpilRootoglu4.SetActive(true);
        }

        else if (DeathCounterforChildParrentSet == 4)
        {
            SerpilRootoglu4.SetActive(false);
            SerpilRootoglu5.SetActive(true);
        }

        else if (DeathCounterforChildParrentSet == 5)
        {
            SerpilRootoglu5.SetActive(false);
            SerpilRootoglu6.SetActive(true);
        }
    }
}
