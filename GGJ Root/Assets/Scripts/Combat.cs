using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Combat : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPreFab;
<<<<<<< Updated upstream
    public float gun_accuracy, gun_fireRate, gun_damage, nextFireTime;
=======
    public float gun_accuracy,gun_fireRate,gun_damage, nextFireTime;
>>>>>>> Stashed changes


    //[SerializeField] ParticleSystem particle = null;
    //[SerializeField] ParticleSystem bloodParticle1 = null;
    //[SerializeField] ParticleSystem bloodParticle2 = null;
    //[SerializeField] ParticleSystem chargedParticle = null;
    //[SerializeField] ParticleSystem chargedAttackParticle = null;
    //[SerializeField] ParticleSystem chargingParticle = null;

    public Animator animator;

    //public GameObject deflectLight;
    //public Animator deflectLightanim;

    public Transform attackPoint;
    //public Transform DeflectPoint2;

    public float AttackRadius = 0.5f;
    public float hpdamage = 5f;
    public float attackposturedamage = 5f;
    //public float deflectposturedamage = 10f;
    public float sarpAttackDirectionCounter;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    //public float deflectRate = 2f;
    //float nextDeflectTime = 0f;
    //public bool camZoom;
    //public bool deathblowSound;

    public LayerMask SwordenemyLayer;
    public LayerMask GunenemyLayer;
    //public LayerMask EnemiesLayer;
    //public LayerMask BossLayer;
    public LayerMask BulletLayer;
    //public LayerMask SwordLayer;
    //public LayerMask BossSwordLayer;

    public Vector2 boyut;

    void Start()
    {
        gun_accuracy = 5f;
        gun_fireRate = 1f;
        gun_damage = 5f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }

        if (Time.time >= nextFireTime)
        {
            if (Input.GetMouseButton(1))
            {
                Shoot();
                nextFireTime = Time.time + 1f / gun_fireRate;

            }
        }

<<<<<<< Updated upstream

=======
            
>>>>>>> Stashed changes
        //PARTICLE
        //ParticleStopper();
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //DEATHBLOW STUFF

                /*if (deathblowSound)
                {
                    chargedAttackParticle.Play();
                }*/

                //TEMPORARY. YOU SHOULD CALL ATTACK FUNTION IN ATTACK ANIMATION.


                sarpAttackDirectionCounter++;
                Attack();
                //DEATHBLOW
                //DeathblowBeforeAttack();
                nextAttackTime = Time.time + 1f / attackRate;
                if (sarpAttackDirectionCounter % 2 == 0)
                {
                    //ATTACK ANIMATIONS
                    //int parametreisAttack = Animator.StringToHash("isAttack");
                    //animator.SetTrigger(parametreisAttack);
                }
                if (sarpAttackDirectionCounter % 2 == 1)
                {
                    //ATTACK ANIMATIONS
                    //int parametreisAttack2 = Animator.StringToHash("isAttack2");
                    //animator.SetTrigger(parametreisAttack2);
                }
            }
        }
    }

    public void Shoot()
    {
        Quaternion rotation = firePoint.rotation;
        float dif = Random.value / (10 * gun_accuracy);

        if (Random.Range(0, 2) == 0)
        {
            rotation.z += dif;
        }
        else
        {
            rotation.z -= dif;
        }

        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, rotation);

        bullet.GetComponent<Bullet>().damage = gun_damage;

    }

    public void Attack()
    {

        Collider2D[] hitswordenemy = Physics2D.OverlapCircleAll(attackPoint.position, AttackRadius, SwordenemyLayer);

        foreach (Collider2D enemy in hitswordenemy)
        {
            //SWORD ENEMY ATTACK STUN STUFF

            /*if (GameObject.Find("GameController").GetComponent<StunCounter>().counter == 1)
            {
                GetComponent<Combat>().deathblowSound = false;
                KatanaLight.SetActive(false);
                GetComponent<Combat>().ParticleStopper();
                GameObject.Find("GameController").GetComponent<StunCounter>().counter--;
                if (GameObject.Find("GameController").GetComponent<StunCounter>().counter < 0)
                    GameObject.Find("GameController").GetComponent<StunCounter>().counter = 0;
                DamageDecrease();
            }*/

            //ENEMY KILL HP DAMAGE

            if (0 >= enemy.GetComponent<Enemy>().CurrentHealt - hpdamage)
            {
                enemy.GetComponent<Enemy>().TakeDamage(hpdamage);
                //if(enemy.GetComponentInChildren<DamageBar>().damageDecrease==true)
                //enemy.GetComponentInChildren<DamageBar>().a = 0;
                //enemy.GetComponent<Enemy>().TakeDamage(hpdamage, attackposturedamage);
                CameraShaker.Instance.ShakeOnce(10f, 50f, .1f, 1f);
                Debug.Log("ATTACK SHAKE");
            }

            //ENEMY NORMAL HP DAMAGE

            else
            {
                enemy.GetComponent<Enemy>().TakeDamage(hpdamage);
                //GameObject.Find("EnemySoundRandomizer 1").GetComponent<EnemyDeathSoundRandomizer>().SarpHitEnemy();
                CameraShaker.Instance.ShakeOnce(7f, 12.5f, .1f, .5f);

                //if (enemy.GetComponent<Enemy>().sj == true)
                //enemy.GetComponent<Enemy>().a = 0;

                //if (enemy.GetComponentInChildren<DamageBar>().damageDecrease == true)
                //enemy.GetComponentInChildren<DamageBar>().a = 0;

                //enemy.GetComponent<Enemy>().sj = false;
                Debug.Log("HIT SHAKE");

                /*GameObject HitSplasher = ObjectPool.SharedInstance.GetPooledHitSplasher();
                if (HitSplasher != null)
                {
                    HitSplasher.transform.position = enemy.transform.position;
                    HitSplasher.transform.rotation = enemy.transform.rotation;
                    HitSplasher.SetActive(true);
                }*/
            }

            //ATTACK STUN STUFF

            /*if (enemy.GetComponent<Enemy>().CurrentPosture >= enemy.GetComponent<Enemy>().MaxPosture && enemy.GetComponent<Enemy>().CurrentHealt > 0 && enemy.GetComponent<EnemyStun>().countt == 0)
            {
                GameObject.Find("EnemySoundRandomizer 1").GetComponent<EnemyDeathSoundRandomizer>().SarpAttackStun();
                enemy.GetComponent<EnemyStun>().countt++;
            }*/
            //enemy.GetComponentInChildren<BloodSplashController>().bloodSplashManager = true;

        }

        Collider2D[] hitgunenemy = Physics2D.OverlapCircleAll(attackPoint.position, AttackRadius, GunenemyLayer);

        foreach (Collider2D enemy in hitgunenemy)
        {
            //GUNENEMY ATTACK STUN STUFF

            /*if (GameObject.Find("GameController").GetComponent<StunCounter>().counter == 1)
            {
                GetComponent<Combat>().deathblowSound = false;
                KatanaLight.SetActive(false);
                GetComponent<Combat>().ParticleStopper();
                GameObject.Find("GameController").GetComponent<StunCounter>().counter--;
                if (GameObject.Find("GameController").GetComponent<StunCounter>().counter < 0)
                    GameObject.Find("GameController").GetComponent<StunCounter>().counter = 0;
                DamageDecrease();
            }*/

            //GUN ENEMY KILL HP DAMAGE

            if (0 >= enemy.GetComponent<EnemyGunDying>().CurrentHealt - hpdamage)
            {
                enemy.GetComponent<EnemyGunDying>().TakeDamage(hpdamage);
                CameraShaker.Instance.ShakeOnce(10f, 50f, .1f, 1f);
            }

            //GUN ENEMY NORMAL HP DAMAGE

            else
            {
                enemy.GetComponent<EnemyGunDying>().TakeDamage(hpdamage);
                //GameObject.Find("GunEnemySoundRandomizer 1").GetComponent<EnemyGunRandomizerTemp>().SarpHitEnemy2();
                CameraShaker.Instance.ShakeOnce(7f, 12.5f, .1f, .5f);

                /*if (enemy.GetComponent<EnemyGunDying>().sj == true)
                    enemy.GetComponent<EnemyGunDying>().a = 0;

                enemy.GetComponent<EnemyGunDying>().a = 0;

                GameObject HitSplasher = ObjectPool.SharedInstance.GetPooledHitSplasher();
                if (HitSplasher != null)
                {
                    HitSplasher.transform.position = enemy.transform.position;
                    HitSplasher.transform.rotation = enemy.transform.rotation;
                    HitSplasher.SetActive(true);
                }*/
            }

            //GUN ENEMY ATTACK STUN STUFF

            /*if (enemy.GetComponent<EnemyGunDying>().CurrentPosture >= enemy.GetComponent<EnemyGunDying>().MaxPosture && enemy.GetComponent<EnemyGunDying>().CurrentHealt != 1 - hpdamage && enemy.GetComponent<EnemyGunDying>().countt == 0)
            {
                GameObject.Find("GunEnemySoundRandomizer 1").GetComponent<EnemyGunRandomizerTemp>().SarpAttackStun2();
                //enemy.GetComponent<EnemyGunDying>().countt++;
            }*/
            //enemy.GetComponentInChildren<BloodSplashController>().bloodSplashManager = true;
        }

        //BOSS

        /*Collider2D[] hitboss = Physics2D.OverlapCircleAll(attackPoint.position, AttackRadius, BossLayer);

        foreach (Collider2D boss in hitboss)
        {
            boss.GetComponent<Boss_Shooting>().BossHealth(hpdamage);
            CameraShaker.Instance.ShakeOnce(7f, 50f, .1f, 1f);
            //BloodParticlePlay();
        }*/

    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(DeflectPoint2.position, boyut);
        Gizmos.DrawSphere(attackPoint.position, AttackRadius);
    }
}