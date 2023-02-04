using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public Transform Parent;
    public Transform Child;
    public float moveSpeed = 2f;
    private bool moveCamera = false;
    private bool setpositiontoparent = false;
    public GameObject canvas2;
    public Image fadeImage;
    [SerializeField] CinemachineVirtualCamera vcam;

    void Update()
    {
        if (moveCamera)
        {
            transform.position = Vector3.Lerp(transform.position, Child.position, moveSpeed * Time.deltaTime);
            vcam.m_Follow = this.transform;
            if (Vector3.Distance(transform.position, Child.position) == 0f)
            {
                moveCamera = false;
            }
        }
        if (setpositiontoparent)
        {
            vcam.m_Follow = Parent.transform;
        }
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
}
