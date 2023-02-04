using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FamilyTreeStatInformer : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public TextMeshProUGUI enemiesKilledText;
    public TextMeshProUGUI shotsFiredText;
    public float enemiesKilled;
    public float shotsFired;
    public float lerpTime = 1f;
    private float startTime;
    public bool bool1 = false;
    public bool bool2 = false;



    private void Start()
    {
        enemiesKilled = Random.Range(25, 130);
        shotsFired = Random.Range(150, 1500);
    }

    void Update()
    {
        if (bool1)
        {
            int currentEnemiesKilled = Mathf.RoundToInt(Mathf.Lerp(0, enemiesKilled, (Time.time - startTime) / lerpTime));
            enemiesKilledText.text = "Enemies Killed: " + currentEnemiesKilled;
            if (currentEnemiesKilled == enemiesKilled)
            {
                bool2 = true;
                bool1 = false;
                startTime = Time.time;
            }
        }
        if (bool2)
        {
            int currentShotsFired = Mathf.RoundToInt(Mathf.Lerp(0, shotsFired, (Time.time - startTime) / lerpTime));
            shotsFiredText.text = "Shots Fired: " + currentShotsFired;
            if (currentShotsFired == shotsFired)
            {
                bool2 = false;
                cameraMovement.moveCamera = true;
                cameraMovement.setpositiontoparent = false;
            }
        }
        
    }

    public void OnPlayerDeath()
    {
        startTime = Time.time;
        bool1 = true;
    }


}


