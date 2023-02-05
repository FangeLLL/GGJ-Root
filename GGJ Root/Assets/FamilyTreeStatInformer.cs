using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static GameControllerScript;
using Slider = UnityEngine.UI.Slider;

public class FamilyTreeStatInformer : MonoBehaviour
{
    public GameControllerScript gameControllerScript;
    public CameraMovement cameraMovement;

    public TextMeshProUGUI ContinueWithSuccessorText;
    public TextMeshProUGUI PlayerCounterText;

    public TextMeshProUGUI GUNenemiesKilledText;
    public TextMeshProUGUI GUNhitCountText;
    public TextMeshProUGUI GUNtotalAccucaryText;
    public TextMeshProUGUI GUNshotsFiredText;
    public TextMeshProUGUI SWORDenemiesKilledText;
    public TextMeshProUGUI SWORDhitCountText;

    public TextMeshProUGUI FireRateSliderText;
    //public TextMeshProUGUI AccuracySliderText;
    public TextMeshProUGUI DamageSliderText;
    public Slider FireRateSlider;
    //public Slider AccuracySlider;
    public Slider DamageSlider;

    public float GUNenemiesKilled;
    public float GUNhitCount;
    public float GUNtotalAccucary;
    public float GUNshotsFired;
    public float SWORDenemiesKilled;
    public float SWORDhitCount;
    public float PlayerCounter = 0;

    private float currentLerpTime;
    private float currentLerpTime2;

    public float lerpTime = 1f;
    public float lerpTime2 = 1f;

    private float startTime;
    public bool bool1 = false;
    public bool bool2 = false;
    public bool bool3 = false;
    public bool bool4 = false;
    public bool bool5 = false;
    public bool bool6 = false;
    public bool keyCodeChecker = false;
    public bool onetimebool1 = true;
    public bool onetimebool2 = true;



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
                bool5 = true;
                startTime = Time.time;

                FireRateSlider.minValue = 0;
                FireRateSlider.maxValue = gameControllerScript.gun.fireRate.barriers[System.Array.IndexOf(gameControllerScript.gun.fireRate.barriers, gameControllerScript.gun.fireRate.start) + 1];
            }
        }

        if (bool5)
        {
            if (currentLerpTime < lerpTime)
            {
                currentLerpTime += Time.deltaTime;
                float t = currentLerpTime / lerpTime;
                FireRateSlider.value = Mathf.Lerp(FireRateSlider.minValue, gameControllerScript.gun.fire_total, t);
            }
            else if(onetimebool1)
            {
                if (gameControllerScript.gun.fire_total >= gameControllerScript.gun.fireRate.barriers[System.Array.IndexOf(gameControllerScript.gun.fireRate.barriers, gameControllerScript.gun.fireRate.start) + 1])
                {
                    float temp = System.Array.IndexOf(gameControllerScript.gun.fireRate.barriers, gameControllerScript.gun.fireRate.start) * gameControllerScript.gun.fireRate.amount;
                    FireRateSliderText.text = "Successor Fire Rate Increased \r\n " + temp + " >> " + (temp + gameControllerScript.gun.fireRate.amount);
                    bool5 = false;
                    bool6 = true;
                    startTime = Time.time;
                    DamageSlider.minValue = 0;
                    DamageSlider.maxValue = gameControllerScript.gun.damage.barriers[System.Array.IndexOf(gameControllerScript.gun.damage.barriers, gameControllerScript.gun.damage.start) + 1];
                    onetimebool1 = false;
                }
                else
                {
                    bool5 = false;
                    bool6 = true;
                    startTime = Time.time;
                    DamageSlider.minValue = 0;
                    DamageSlider.maxValue = gameControllerScript.gun.damage.barriers[System.Array.IndexOf(gameControllerScript.gun.damage.barriers, gameControllerScript.gun.damage.start) + 1];
                    onetimebool1 = false;
                }   
            }
        }

        if (bool6)
        {
            if (currentLerpTime2 < lerpTime2)
            {
                currentLerpTime2 += Time.deltaTime;
                float t = currentLerpTime2 / lerpTime2;
                DamageSlider.value = Mathf.Lerp(DamageSlider.minValue, gameControllerScript.gun.kill, t);
            }
            else if (onetimebool2)
            {
                if (gameControllerScript.gun.kill >= gameControllerScript.gun.damage.barriers[System.Array.IndexOf(gameControllerScript.gun.damage.barriers, gameControllerScript.gun.damage.start) + 1])
                {
                    float temp2 = System.Array.IndexOf(gameControllerScript.gun.damage.barriers, gameControllerScript.gun.damage.start) * gameControllerScript.gun.damage.amount;
                    DamageSliderText.text = "Successor Damage Increased \r\n " + temp2 + " >> " + (temp2 + gameControllerScript.gun.damage.amount);
                    bool6 = false;
                    startTime = Time.time;
                    onetimebool2 = false;
                    keyCodeChecker = true;
                    ContinueWithSuccessorText.text = "Press N Continue With Successor";
                }
                else
                {
                    bool6 = false;
                    startTime = Time.time;
                    onetimebool2 = false;
                    keyCodeChecker = true;
                    ContinueWithSuccessorText.text = "Press N Continue With Successor";
                }
            }
        }



        if (keyCodeChecker)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                cameraMovement.moveCamera = true;
                cameraMovement.setpositiontoparent = false;
                ContinueWithSuccessorText.text = "";
                keyCodeChecker = false;
                gameControllerScript.Inheritance();
            }
        }
        



    }

    public void OnPlayerDeath()
    {
        startTime = Time.time;
        bool1 = true;
        onetimebool1 = true;
        onetimebool2 = true;
        PlayerCounter++;
        PlayerCounterText.text = PlayerCounter + "/6";
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
    }

    public void TextReseter()
    {
        GUNenemiesKilledText.text = "Enemies Killed: 0";
        GUNhitCountText.text = "Hit Count: 0";
        GUNtotalAccucaryText.text = "Total Accucary: %0";
        GUNshotsFiredText.text = "Shots Fired: 0";

        currentLerpTime = 0;
        currentLerpTime2 = 0;

        FireRateSliderText.text = "";
        FireRateSlider.value = 0;

        DamageSliderText.text = "";
        DamageSlider.value = 0;
    }


}


