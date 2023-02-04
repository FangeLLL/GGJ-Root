using System.Collections;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class PlayerKiller : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public GameObject canvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            canvas.SetActive(true);
            cameraMovement.StartCoroutine(cameraMovement.MoveCameraOnPlayerDeath());
        }
    }
}
