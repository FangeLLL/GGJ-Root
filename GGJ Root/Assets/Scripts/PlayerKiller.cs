using System.Collections;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class PlayerKiller : MonoBehaviour
{
    public CameraMovement cameraMovement;
    //public FamilyTreeStatInformer familyTreeStatInformer;

    GameControllerScript gameControllerScript;

    private void Start()
    {
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    private void OnEnable()
    {
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        GetComponent<SpriteRenderer>().color = color;
    }

    public void PlayerDie()
    {
        //familyTreeStatInformer.OnPlayerDeath();
        gameControllerScript.resetScene();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<PlayerMovement>().enabled = false;
        cameraMovement.StartCoroutine(cameraMovement.ManFuckThisGame());
    }

}
