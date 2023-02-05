using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyGunDying : MonoBehaviour
{
    GameControllerScript gameControllerScript;
    WaveSystem waveSystem;

    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;
    public BoxCollider2D col;

    public float CurrentHealt;
    //public float MaxPosture;
    //public float CurrentPosture;
    //public float countt;
    //public float temphp;
    //float Timer;
    //public Animator animator;
    //public Animator gunLegAnimator;
    //public GameObject gunEnemyLight;
    //public GameObject gunEnemyStunLight;
    //public GameObject KatanaLight;
    //public GameObject EnemyLeg;
    //public LayerMask playerLayer;
    //public Transform bloodpoint_gun;
    //public float bloodarea_radius;
    //public bool oneTimeExecutionDarkRedPrint;
    //public bool posturedecrease;
    //int parametrelegWalk = Animator.StringToHash("legWalk");
    //int parametrestun = Animator.StringToHash("Stun");
    //int parametreStunTriggerExit = Animator.StringToHash("StunExit");
    //int parametreFadeInTrigger = Animator.StringToHash("FadeIn");
    //int parametreFadeOutTrigger = Animator.StringToHash("FadeOut");
    public Collider2D col2;
    //bool c;

    //public float a;
    public HealthBar healthBar;
    public DamageBar damageBar;
    public GameObject healthBarObject;
    public GameObject damageBarObject;
    //public PostureBarGunEnemy postureBar;
    //public PostureBarGunEnemy postureBar2;
    //public bool sj;
    public bool knockbackchecker;
    /*public GameObject postureLightMid;
    public GameObject postureLightNearEnd;
    public GameObject postureLightEnd;
    public GameObject PostureBorder;
    public GameObject VerticalStick;
    public GameObject Canvas;*/
    //int parameterEnterTrigger = Animator.StringToHash("Enter");
    //int parameterExitTrigger = Animator.StringToHash("Exit");

    public SpriteRenderer sp;
    public GameObject powerUpPrefab;


    void Start()
    {
        //countt = 0;

        //ENEMY SHOOTING

        //GetComponent<EnemyShooting>().enabled = true;
        //GetComponent<EnemyShooting>().kola.SetActive(true);
        //animator = GetComponent<Animator>();

        //DAMAGE BAR

        healthBar.SetStartingHealth(CurrentHealt);
        damageBar.SetDamageBar(CurrentHealt);
        //postureBar.SetMaxPosture(MaxPosture);
        //postureBar2.SetMaxPosture(MaxPosture);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        waveSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveSystem>();
        col2 = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float hpdamage,string weapon)
    {
        //posturedecrease = false;
        StopAllCoroutines();
        Flash();
        CurrentHealt = CurrentHealt - hpdamage;

        //a = a + posturedamage;
        healthBar.TakeDamage(hpdamage);
        //damageBar.TakeDamage2(hpdamage);

        if (damageBar.damageSlider.value > healthBar.slider.value)
            damageBar.SJ();

        //postureBar.TakePostureDamage(posturedamage);
        //postureBar2.TakePostureDamage(posturedamage);

        /*if (CurrentPosture >= MaxPosture / 2 && posturedecrease == false)
        {
            postureLightMid.SetActive(true);
            postureLightMid.GetComponent<Animator>().SetTrigger(parameterEnterTrigger);
        }

        if (CurrentPosture >= MaxPosture - 15 && posturedecrease == false)
        {
            StartCoroutine(PostureLightMidExit());
            postureLightNearEnd.SetActive(true);
            postureLightNearEnd.GetComponent<Animator>().SetTrigger(parameterEnterTrigger);
        }
        if (CurrentPosture >= MaxPosture && posturedecrease == false)
        {
            StartCoroutine(PostureLightMidExit());
            StartCoroutine(PostureLightNearEndExit());
            postureLightEnd.SetActive(true);
            postureLightEnd.GetComponent<Animator>().SetTrigger(parameterEnterTrigger);
        }

        if (CurrentPosture < MaxPosture)
        {
            StartCoroutine(A());
        }


        //if (CurrentPosture < MaxPosture) Invoke("A", 1.5f);
        /*
        if (CurrentHealt <= 0 && CurrentPosture >= maxPosture)
        {
            //StunDeath
        }
        */

        /*if (CurrentHealt < GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().hpdamage)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().deathblowSound = true;
        }*/

        switch (weapon)
        {
            case "gun":
                gameControllerScript.gun.hit++;
                gameControllerScript.gun.hit_total++;
                break;
            case "magic":
                gameControllerScript.magic.hit++;
                gameControllerScript.magic.hit_total++;
                break;
        }


        if (CurrentHealt <= 0)
        {
            switch (weapon)
            {
                case "sword":
                    gameControllerScript.sword.kill++;
                    gameControllerScript.checkWeaponLevel(gameControllerScript.sword, "sword");
                    gameControllerScript.checkDamage(gameControllerScript.sword, "sword");
                    break;
                case "gun":
                    CameraShaker.Instance.ShakeOnce(10f, 50f, .1f, 1f);
                    gameControllerScript.gun.kill++;
                    gameControllerScript.checkWeaponLevel(gameControllerScript.gun, "gun");
                    gameControllerScript.checkDamage(gameControllerScript.gun, "gun");
                    break;
                case "magic":
                    gameControllerScript.magic.kill++;
                    break;
            }
            gameControllerScript.score += 150 * gameControllerScript.streak;
            gameControllerScript.checkScore();
            waveSystem.totalEnemy--;
            waveSystem.generateWave();
            Die31();
        }

        /*else if (CurrentPosture >= MaxPosture)
        {
            Stun31();
            VerticalStick.SetActive(false);
            //postureBar.fill.color = postureBar.gradient.Evaluate(1f);
            postureBar.PostureBarMaxtoZero();
            //postureBar2.fill.color = postureBar2.gradient.Evaluate(1f);
            postureBar2.PostureBarMaxtoZero();
        }
        */
        else
            GetComponent<Enemy_Knockback>().Knockback();
    }
    void Die31()
    {
        col2.enabled = false;
        healthBarObject.SetActive(false);
        damageBarObject.SetActive(false);
      //  this.GetComponentInChildren<EnemyGunRandomizerTemp>().SerpilKillsGunEnemy();
        StartCoroutine(DieDelay());
    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(.126f);
        sp.enabled = false;
        this.GetComponent<EnemyAI2>().enabled = false;
        this.GetComponent<EnemyLookDir>().enabled = false;
        yield return new WaitForSeconds(2f);
        if (gameControllerScript.PowerUps.Count != 0 && Random.Range(0, 3) == 0)
        {
            GameObject powerUpInstance = Instantiate(powerUpPrefab, transform.position, transform.rotation);
            int loc = 1;
            switch (gameControllerScript.PowerUps[Random.Range(0, gameControllerScript.PowerUps.Count)])
            {
                case "Gun":
                    loc = 2;
                    break;
                case "Magic":
                    loc = 1;
                    break;
            }
            powerUpInstance.transform.GetChild(loc).gameObject.SetActive(true);
        }
        Destroy(gameObject);
    }


    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }

    public void Flash()
    {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);

        flashRoutine = StartCoroutine(FlashRoutine());
    }

}
