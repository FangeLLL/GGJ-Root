using System.Collections;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class PlayerKiller : MonoBehaviour
{
    public CameraMovement cameraMovement;

    private void OnEnable()
    {
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        GetComponent<SpriteRenderer>().color = color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<PlayerMovement>().enabled = false;
            cameraMovement.StartCoroutine(cameraMovement.ManFuckThisGame());
        }
    }

}
