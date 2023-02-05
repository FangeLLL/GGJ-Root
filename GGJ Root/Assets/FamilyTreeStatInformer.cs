using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FamilyTreeStatInformer : MonoBehaviour
{
    public GameControllerScript gameControllerScript;
    public CameraMovement cameraMovement;

    public TextMeshProUGUI GUNenemiesKilledText;
    public TextMeshProUGUI GUNhitCountText;
    public TextMeshProUGUI GUNtotalAccucaryText;
    public TextMeshProUGUI GUNshotsFiredText;
    public TextMeshProUGUI SWORDenemiesKilledText;
    public TextMeshProUGUI SWORDhitCountText;

    public float GUNenemiesKilled;
    public float GUNhitCount;
    public float GUNtotalAccucary;
    public float GUNshotsFired;
    public float SWORDenemiesKilled;
    public float SWORDhitCount;

    public float lerpTime = 1f;
    private float startTime;
    public bool bool1 = false;
    public bool bool2 = false;
    public bool bool3 = false;
    public bool bool4 = false;



    void Update()
    {
        if (bool1)
        {
            int currentGUNEnemiesKilled = Mathf.RoundToInt(Mathf.Lerp(0, GUNenemiesKilled, (Time.time - startTime) / lerpTime));
            GUNenemiesKilledText.text = "Enemies Killed: " + currentGUNEnemiesKilled;
            if (currentGUNEnemiesKilled == GUNenemiesKilled)
            {
                bool2 = true;
                bool1 = false;
                startTime = Time.time;
            }
        }

        if (bool2)
        {
            int currentGUNhitCount = Mathf.RoundToInt(Mathf.Lerp(0, GUNhitCount, (Time.time - startTime) / lerpTime));
            GUNhitCountText.text = "Hit Count: " + currentGUNhitCount;
            if (currentGUNhitCount == GUNhitCount)
            {
                bool3 = true;
                bool2 = false;
                startTime = Time.time;
            }
        }

        if (bool3)
        {
            int currentGUNtotalAccucary = Mathf.RoundToInt(Mathf.Lerp(0, GUNtotalAccucary, (Time.time - startTime) / lerpTime));
            GUNtotalAccucaryText.text = "Total Accucary: %" + currentGUNtotalAccucary;
            if (currentGUNtotalAccucary == GUNtotalAccucary)
            {
                bool4 = true;
                bool3 = false;
                startTime = Time.time;
            }
        }

        if (bool4)
        {
            int currentGUNShotsFired = Mathf.RoundToInt(Mathf.Lerp(0, GUNshotsFired, (Time.time - startTime) / lerpTime));
            GUNshotsFiredText.text = "Shots Fired: " + currentGUNShotsFired;
            if (currentGUNShotsFired == GUNshotsFired)
            {
                bool4 = false;
                //cameraMovement.moveCamera = true;
                //cameraMovement.setpositiontoparent = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraMovement.moveCamera = true;
            cameraMovement.setpositiontoparent = false;
        }



    }

    public void OnPlayerDeath()
    {
        startTime = Time.time;
        bool1 = true;

        GUNenemiesKilled = gameControllerScript.gun.kill;
        GUNhitCount = gameControllerScript.gun.hit_total;
        if (gameControllerScript.gun.fire_total == 0)
        {
            GUNtotalAccucary = 0;
        }
        else
        {
            GUNtotalAccucary = Mathf.RoundToInt((gameControllerScript.gun.hit_total / gameControllerScript.gun.fire_total) * 100);
        }
        GUNshotsFired = gameControllerScript.gun.fire_total;
        SWORDenemiesKilled = gameControllerScript.sword.kill;
        SWORDhitCount = gameControllerScript.sword.fire_total;
        gameControllerScript.Inheritance();
    }


}


