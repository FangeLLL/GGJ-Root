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

    public TextMeshProUGUI RootExtinctText;

    public TextMeshProUGUI ContinueWithSuccessorText;
    public TextMeshProUGUI PlayerCounterText;

    public TextMeshProUGUI GUNenemiesKilledText;
    public TextMeshProUGUI GUNhitCountText;
    public TextMeshProUGUI GUNtotalAccucaryText;
    public TextMeshProUGUI GUNshotsFiredText;
    public TextMeshProUGUI SWORDenemiesKilledText;
    public TextMeshProUGUI SWORDhitCountText;

    public TextMeshProUGUI GUNFireRateSliderText;
    public TextMeshProUGUI SWORDFireRateSliderText;
    public TextMeshProUGUI GUNAccuracySliderText;
    public TextMeshProUGUI GUNDamageSliderText;
    public TextMeshProUGUI SWORDDamageSliderText;

    public Slider GUNFireRateSlider;
    public Slider SWORDFireRateSlider;
    public Slider GUNAccuracySlider;
    public Slider GUNDamageSlider;
    public Slider SWORDDamageSlider;

    public float GUNenemiesKilled;
    public float GUNhitCount;
    public float GUNtotalAccucary;
    public float GUNshotsFired;
    public float SWORDenemiesKilled;
    public float SWORDhitCount;
    public float PlayerCounter = 0;

    private float currentLerpTime;
    private float currentLerpTime2;
    private float currentLerpTime3;
    private float currentLerpTime4;
    private float currentLerpTime5;

    private float lerpTime = 1f;
    private float lerpTime2 = 1f;
    private float lerpTime3 = 1f;
    private float lerpTime4 = 1f;

    private float startTime;
    private bool swordbool1 = false;
    private bool swordbool2 = false;
    private bool swordbool3 = false;
    private bool swordbool4 = false;
    private bool bool1 = false;
    private bool bool2 = false;
    private bool bool3 = false;
    public bool bool4 = false;
    private bool bool5 = false;
    private bool bool6 = false;
    private bool keyCodeChecker = false;
    private bool onetimebool1 = true;
    private bool onetimebool2 = true;
    private bool onetimebool3 = true;
    private bool onetimebool4 = true;



    void Update()
    {
        if (swordbool1)
        {
            int currentSWORDenemiesKilled = Mathf.RoundToInt(Mathf.Lerp(0, SWORDenemiesKilled, (Time.time - startTime) / lerpTime));
            SWORDenemiesKilledText.text = "Enemies Killed: " + currentSWORDenemiesKilled;
            if (currentSWORDenemiesKilled == SWORDenemiesKilled)
            {
                swordbool2 = true;
                swordbool1 = false;
                startTime = Time.time;
            }
        }

        if (swordbool2)
        {
            int currentSWORDhitCount = Mathf.RoundToInt(Mathf.Lerp(0, SWORDhitCount, (Time.time - startTime) / lerpTime));
            SWORDhitCountText.text = "Hit Count: " + currentSWORDhitCount;
            if (currentSWORDhitCount == SWORDhitCount)
            {
                swordbool3 = true;
                swordbool2 = false;
                startTime = Time.time;
                SWORDFireRateSlider.minValue = 0;
                SWORDFireRateSlider.maxValue = gameControllerScript.sword.fireRate.barriers[System.Array.IndexOf(gameControllerScript.sword.fireRate.barriers, gameControllerScript.sword.fireRate.start) + 1];
            }
        }

        if (swordbool3)
        {
            if (currentLerpTime3 < lerpTime3)
            {
                currentLerpTime3 += Time.deltaTime;
                float t = currentLerpTime3 / lerpTime3;
                SWORDFireRateSlider.value = Mathf.Lerp(SWORDFireRateSlider.minValue, gameControllerScript.sword.fire_total, t);
            }
            else if (onetimebool3)
            {
                if (gameControllerScript.sword.fire_total >= gameControllerScript.sword.fireRate.barriers[System.Array.IndexOf(gameControllerScript.sword.fireRate.barriers, gameControllerScript.sword.fireRate.start) + 1])
                {
                    float temp4 = System.Array.IndexOf(gameControllerScript.sword.fireRate.barriers, gameControllerScript.sword.fireRate.start) * gameControllerScript.sword.fireRate.amount;
                    SWORDFireRateSliderText.text = "Successor Fire Rate Increased \r\n " + temp4 + " >> " + (temp4 + gameControllerScript.sword.fireRate.amount);
                    swordbool3 = false;
                    swordbool4 = true;
                    startTime = Time.time;
                    onetimebool3 = false;
                    SWORDDamageSlider.minValue = 0;
                    SWORDDamageSlider.maxValue = gameControllerScript.sword.damage.barriers[System.Array.IndexOf(gameControllerScript.sword.damage.barriers, gameControllerScript.sword.damage.start) + 1];
                }
                else
                {
                    swordbool3 = false;
                    swordbool4 = true;
                    startTime = Time.time;
                    onetimebool3 = false;
                    SWORDDamageSlider.minValue = 0;
                    SWORDDamageSlider.maxValue = gameControllerScript.sword.damage.barriers[System.Array.IndexOf(gameControllerScript.sword.damage.barriers, gameControllerScript.sword.damage.start) + 1];
                }
            }
        }
            
        if (swordbool4)
        {
            if (currentLerpTime4 < lerpTime4)
            {
                currentLerpTime4 += Time.deltaTime;
                float t = currentLerpTime4 / lerpTime4;
                SWORDDamageSlider.value = Mathf.Lerp(SWORDDamageSlider.minValue, gameControllerScript.sword.kill, t);
            }
            else if (onetimebool4)
            {
                if (gameControllerScript.sword.kill >= gameControllerScript.sword.damage.barriers[System.Array.IndexOf(gameControllerScript.sword.damage.barriers, gameControllerScript.sword.damage.start) + 1])
                {
                    float temp4 = System.Array.IndexOf(gameControllerScript.sword.damage.barriers, gameControllerScript.sword.damage.start) * gameControllerScript.sword.damage.amount;
                    SWORDDamageSliderText.text = "Successor Damage Increased \r\n " + temp4 + " >> " + (temp4 + gameControllerScript.sword.damage.amount);
                    swordbool4 = false;
                    bool1 = true;
                    startTime = Time.time;
                    onetimebool4 = false;
                }
                else
                {
                    swordbool4 = false;
                    bool1 = true;
                    startTime = Time.time;
                    onetimebool4 = false;
                }
            }
        }

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
                bool5 = true;
                bool4 = false;
                startTime = Time.time;

                GUNFireRateSlider.minValue = 0;
                GUNFireRateSlider.maxValue = gameControllerScript.gun.fireRate.barriers[System.Array.IndexOf(gameControllerScript.gun.fireRate.barriers, gameControllerScript.gun.fireRate.start) + 1];
            }
        }

        if (bool5)
        {
            if (currentLerpTime < lerpTime)
            {
                currentLerpTime += Time.deltaTime;
                float t = currentLerpTime / lerpTime;
                GUNFireRateSlider.value = Mathf.Lerp(GUNFireRateSlider.minValue, gameControllerScript.gun.fire_total, t);
            }
            else if(onetimebool1)
            {
                if (gameControllerScript.gun.fire_total >= gameControllerScript.gun.fireRate.barriers[System.Array.IndexOf(gameControllerScript.gun.fireRate.barriers, gameControllerScript.gun.fireRate.start) + 1])
                {
                    float temp = System.Array.IndexOf(gameControllerScript.gun.fireRate.barriers, gameControllerScript.gun.fireRate.start) * gameControllerScript.gun.fireRate.amount;
                    GUNFireRateSliderText.text = "Successor Fire Rate Increased \r\n " + temp + " >> " + (temp + gameControllerScript.gun.fireRate.amount);
                    bool5 = false;
                    bool6 = true;
                    startTime = Time.time;
                    GUNDamageSlider.minValue = 0;
                    GUNDamageSlider.maxValue = gameControllerScript.gun.damage.barriers[System.Array.IndexOf(gameControllerScript.gun.damage.barriers, gameControllerScript.gun.damage.start) + 1];
                    onetimebool1 = false;
                }
                else
                {
                    bool5 = false;
                    bool6 = true;
                    startTime = Time.time;
                    GUNDamageSlider.minValue = 0;
                    GUNDamageSlider.maxValue = gameControllerScript.gun.damage.barriers[System.Array.IndexOf(gameControllerScript.gun.damage.barriers, gameControllerScript.gun.damage.start) + 1];
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
                GUNDamageSlider.value = Mathf.Lerp(GUNDamageSlider.minValue, gameControllerScript.gun.kill, t);
            }
            else if (onetimebool2)
            {
                if (gameControllerScript.gun.kill >= gameControllerScript.gun.damage.barriers[System.Array.IndexOf(gameControllerScript.gun.damage.barriers, gameControllerScript.gun.damage.start) + 1])
                {
                    float temp2 = System.Array.IndexOf(gameControllerScript.gun.damage.barriers, gameControllerScript.gun.damage.start) * gameControllerScript.gun.damage.amount;
                    GUNDamageSliderText.text = "Successor Damage Increased \r\n " + temp2 + " >> " + (temp2 + gameControllerScript.gun.damage.amount);
                    bool6 = false;
                    startTime = Time.time;
                    onetimebool2 = false;

                    keyCodeChecker = true;
                    if (cameraMovement.DeathCounterforChildParrentSet == 6)
                    {
                        RootExtinctText.text = "YOUR FAMILY ROOT HAS EXTINCT";
                    }
                    ContinueWithSuccessorText.text = "Press N Continue With Successor";
                }
                else
                {
                    bool6 = false;
                    startTime = Time.time;
                    onetimebool2 = false;

                    keyCodeChecker = true;
                    if (cameraMovement.DeathCounterforChildParrentSet == 6)
                    {
                        RootExtinctText.text = "YOUR FAMILY ROOT HAS EXTINCT";
                    }
                    ContinueWithSuccessorText.text = "Press N Continue With Successor";
                }
            }
        }

        if (keyCodeChecker)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (cameraMovement.DeathCounterforChildParrentSet == 6)
                {
                    cameraMovement.StartCoroutine(cameraMovement.SCENERESET());
                }
                else
                {
                    cameraMovement.moveCamera = true;
                    cameraMovement.setpositiontoparent = false;
                    ContinueWithSuccessorText.text = "";
                    keyCodeChecker = false;
                    gameControllerScript.Inheritance();
                }

            }
        }

    }

    public void OnPlayerDeath()
    {
        startTime = Time.time;
        swordbool1 = true;
        onetimebool1 = true;
        onetimebool2 = true;
        onetimebool3 = true;
        onetimebool4 = true;
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
            GUNtotalAccucary = ((gameControllerScript.gun.hit_total / gameControllerScript.gun.fire_total)*100);
        }
        GUNshotsFired = gameControllerScript.gun.fire_total;
        SWORDenemiesKilled = gameControllerScript.sword.kill;
        SWORDhitCount = gameControllerScript.sword.fire_total;
    }

    public void TextReseter()
    {
        SWORDenemiesKilledText.text = "";
        SWORDhitCountText.text = "";

        GUNenemiesKilledText.text = "";
        GUNhitCountText.text = "";
        GUNtotalAccucaryText.text = "";
        GUNshotsFiredText.text = "";

        currentLerpTime = 0;
        currentLerpTime2 = 0;
        currentLerpTime3 = 0;
        currentLerpTime4 = 0;

        GUNFireRateSliderText.text = "";
        GUNFireRateSlider.value = 0;
        SWORDFireRateSliderText.text = "";
        SWORDFireRateSlider.value = 0;

        GUNDamageSliderText.text = "";
        GUNDamageSlider.value = 0;
        SWORDDamageSliderText.text = "";
        SWORDDamageSlider.value = 0;

        GUNAccuracySliderText.text = "";
        GUNAccuracySlider.value = 0;
    }


}


