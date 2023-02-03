using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;
    public float CurrentHealt;
    //public float CurrentPosture;
    //public float MaxPosture;
    //public float a;
    //public bool posturedecrease;
    //public HealthBar healthBar;
    //public DamageBar damageBar;
    //public PostureBar postureBar;
    //public PostureBar postureBar2;
    //float Timer;
    //public bool sj;
    //public GameObject postureLightMid;
    //public GameObject postureLightNearEnd;
    //public GameObject postureLightEnd;
    //public GameObject PostureBorder;
    //public GameObject VerticalStick;
    int parameterEnterTrigger = Animator.StringToHash("Enter");
    int parameterExitTrigger = Animator.StringToHash("Exit");



    private void Start()
    {
        //healthBar.SetStartingHealth(CurrentHealt);
        //damageBar.SetDamageBar(CurrentHealt);
        //postureBar.SetMaxPosture(MaxPosture);
        //postureBar2.SetMaxPosture(MaxPosture);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void TakeDamage(float hpdamage)
    {
        //posturedecrease = false;
        StopAllCoroutines();
        Flash();
        CurrentHealt = CurrentHealt - hpdamage;
            //CurrentPosture = CurrentPosture + posturedamage;
            //a = a + posturedamage;
            //healthBar.TakeDamage(hpdamage);
            //damageBar.TakeDamage2(hpdamage);

            //POSTURE BAR STUFF

            /*if (PostureBorder.activeSelf == false && VerticalStick.activeSelf == false && CurrentPosture >= MaxPosture)
                PostureBorder.SetActive(true);

            if (PostureBorder.activeSelf == false && VerticalStick.activeSelf == false && CurrentPosture < MaxPosture)
            {
                PostureBorder.SetActive(true);
                VerticalStick.SetActive(true);
            }*/

            //DAMAGEBAR STUFF

            /*if (damageBar.damageSlider.value > healthBar.slider.value)
                damageBar.SJ();*/

            //postureBar.TakePostureDamage(posturedamage);
            //postureBar2.TakePostureDamage(posturedamage);

            //POSTURE STUFF

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
            }*/




            //ENEMY DEATH STUF

            //ENEMY STUN DEATH

            /*if (CurrentHealt <= 0 && CurrentPosture >= MaxPosture)
            {
                GetComponent<Enemy_Death>().StunDeath();
            }*/

        if (CurrentHealt <= 0)
        {
            GetComponent<Enemy>().Die();
        }

            //ENEMY POSTURE STUFF

            /*else if (CurrentPosture >= MaxPosture)
            {
                GetComponent<EnemyStun>().Stun();
                VerticalStick.SetActive(false);
                //postureBar.fill.color = postureBar.gradient.Evaluate(1f);
                postureBar.PostureBarMaxtoZero();
                //postureBar2.fill.color = postureBar2.gradient.Evaluate(1f);
                postureBar2.PostureBarMaxtoZero();
            }*/

            //ENEMY KNOCKBACK

         else
            GetComponent<Enemy_Knockback>().Knockback();


    }

    public void Die()
    {
        Destroy(gameObject);
    }

    //POSTURE STUFF

    //private void Update()
    //{
    /*if (CurrentPosture > 15f)
    {
        CurrentPosture = 15f;
    }*/

    /*if (sj)
    {
        if (postureLightMid.activeSelf == true)
            StartCoroutine(PostureLightMidExit());

        if (postureLightNearEnd.activeSelf == true)
            StartCoroutine(PostureLightNearEndExit());

        if (CurrentPosture < 1)
        {
            PostureBorder.SetActive(false);
            VerticalStick.SetActive(false);
            postureBar.slider.value = 0;
            postureBar2.slider.value = 0;
            sj = false;
            a = 0;
        }

        else
        {
            CurrentPosture = Mathf.Lerp(CurrentPosture, 0, a / 80f);

            postureBar.slider.value = Mathf.Lerp(postureBar.slider.value, 0, a / 80f);
            postureBar2.slider.value = Mathf.Lerp(postureBar.slider.value, 0, a / 80f);
            a += Time.deltaTime;
        }
    }
}*/

    //POSTURE STUFF

    /*private void FixedUpdate()
    {
        if (posturedecrease)
        {
            Timer = Time.time;

            if (Timer % 1 == 0)
            {
                if (CurrentPosture < 1)
                    posturedecrease = false;
                else
                    sj = true;
            }
        }
    }*/

    //POSTURE STUFF

    /*public IEnumerator A()
    {
        if (CurrentPosture > 0)
        {
            yield return new WaitForSeconds(3);
            posturedecrease = true;
        }
    }*/

    //POSTURE STUFF

    /*public IEnumerator PostureLightMidExit()
    {
        postureLightMid.GetComponent<Animator>().SetTrigger(parameterExitTrigger);
        yield return new WaitForSeconds(.6f);
        postureLightMid.SetActive(false);
    }

    public IEnumerator PostureLightNearEndExit()
    {
        postureLightNearEnd.GetComponent<Animator>().SetTrigger(parameterExitTrigger);
        yield return new WaitForSeconds(.6f);
        postureLightNearEnd.SetActive(false);
    }

    public IEnumerator PostureLightEndExit()
    {
        postureLightEnd.GetComponent<Animator>().SetTrigger(parameterExitTrigger);
        yield return new WaitForSeconds(.6f);
        postureLightEnd.SetActive(false);
    }*/


    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }

    //POSTURE STUFF

    /*public void PostureLightMidExitCaller()
    {
        StartCoroutine(PostureLightMidExit());
    }

    public void PostureLightNearEndExitCaller()
    {
        StartCoroutine(PostureLightNearEndExit());
    }

    public void PostureLightEndExitCaller()
    {
        StartCoroutine(PostureLightEndExit());
    }*/

    public void Flash()
    {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);

        flashRoutine = StartCoroutine(FlashRoutine());
    }
}
