using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyGunDying : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

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
    public Collider2D col;
    //bool c;

    //public float a;
    //public HealthBar healthBar;
    //public DamageBar damageBar;
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



    void Start()
    {
        //countt = 0;

        //ENEMY SHOOTING

        //GetComponent<EnemyShooting>().enabled = true;
        //GetComponent<EnemyShooting>().kola.SetActive(true);
        //animator = GetComponent<Animator>();

        //DAMAGE BAR

        /*healthBar.SetStartingHealth(CurrentHealt);
        damageBar.SetDamageBar(CurrentHealt);
        postureBar.SetMaxPosture(MaxPosture);
        postureBar2.SetMaxPosture(MaxPosture);*/
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }
    public void TakeDamage(float hpdamage)
    {
        //posturedecrease = false;
        StopAllCoroutines();
        Flash();
        CurrentHealt = CurrentHealt - hpdamage;

        //a = a + posturedamage;
        //healthBar.TakeDamage(hpdamage);
        //damageBar.TakeDamage2(hpdamage);

        /*if (damageBar.damageSlider.value > healthBar.slider.value)
            damageBar.SJ();*/

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
        if (CurrentHealt <= 0)
        {
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
