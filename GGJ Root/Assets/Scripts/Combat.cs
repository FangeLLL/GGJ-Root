using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using Cinemachine;
using static GameControllerScript;
using static Combat;

public class Combat : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin noise;

    public CameraShake3 cs3;

    public Transform firePoint;
    public GameObject bulletPreFab;
    public float nextFireTime;
    public int gun_level, magic_level, sword_level;

    public class Gun
    {
        public float accuracy, fireRate, damage, bulletSpeed;
        public bool auto;

        public Gun(float acc, float fireR, float dam, float bulletS, bool aut)
        {
            accuracy = acc;
            fireRate = fireR;
            damage = dam;
            bulletSpeed = bulletS;
            auto = aut;
        }

    }

    public Gun currentGun;

    public Gun pistol = new Gun(2, 2, 20, 7, false);
    public Gun machineGun = new Gun(1, 7, 20, 7, true);
    public Gun doublePistol = new Gun(1.5f, 4, 2, 7, false);
    public Gun rifle = new Gun(2, 1, 5, 20, false);

    public class Sword
    {
        public float speed, damage, size;

        public Sword(float spee, float dam, float siz)
        {
            speed = spee;
            damage = dam;
            size = siz;
        }

    }

    public Sword currentSword;

    public Sword branch = new Sword(2f, 5f, 0.5f);
    public Sword bat = new Sword(2f, 7f, 0.7f);
    public Sword knife = new Sword(3f, 8f, 0.6f);

    GameControllerScript gameControllerScript;


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
    public bool deathblowSound;

    public LayerMask SwordenemyLayer;
    public LayerMask GunenemyLayer;
    public LayerMask EnemiesLayer;
    //public LayerMask BossLayer;
    public LayerMask BulletLayer;
    //public LayerMask SwordLayer;
    //public LayerMask BossSwordLayer;

    public Vector2 boyut;

    void Start()
    {
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();

        currentGun = pistol;
        currentGun.damage += gameControllerScript.gun.damage.add;
        currentGun.accuracy += gameControllerScript.gun.accuracy.add;
        currentGun.fireRate += gameControllerScript.gun.fireRate.add;
        gun_level = 0;
        gameControllerScript.gun.accuracy.definer = 1;

        currentSword = branch;
        currentSword.damage += gameControllerScript.sword.damage.add;
        currentSword.speed += gameControllerScript.sword.fireRate.add;
        sword_level = 0;
        AttackRadius = currentSword.size;
        hpdamage = currentSword.damage;
        attackRate = currentSword.speed;
    }

    void Update()
    {

        if (Time.time >= nextFireTime)
        {
            if (Input.GetMouseButtonDown(1) && !currentGun.auto)
            {
                Shoot();
                nextFireTime = Time.time + 1f / currentGun.fireRate;

            }
        }

        if (Time.time >= nextFireTime)
        {
            if (Input.GetMouseButton(1) && currentGun.auto)
            {
                Shoot();
                nextFireTime = Time.time + 1f / currentGun.fireRate;

            }
        }


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
                DeathblowBeforeAttack();
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

    public void levelUpWeapon(string weapon)
    {
        switch (weapon)
        {
            case "gun":
                Debug.Log(gun_level);

                gun_level++;
                switch (gun_level)
                {
                    case 1:
                        Debug.Log("Machine Gun");
                        currentGun = machineGun;
                        gameControllerScript.gun.accuracy.definer = 2;
                        break;
                    case 2:
                        Debug.Log("doublePistol");
                        currentGun = doublePistol;
                        gameControllerScript.gun.accuracy.definer = 1.5f;
                        break;
                    case 3:
                        Debug.Log("rifle");
                        currentGun = rifle;
                        gameControllerScript.gun.accuracy.definer = 1;
                        break;
                }
                currentGun.damage += gameControllerScript.gun.damage.add;
                currentGun.accuracy += gameControllerScript.gun.accuracy.add;
                currentGun.fireRate += gameControllerScript.gun.fireRate.add;
                break;
            case "magic":
                magic_level++;
                switch (magic_level)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                }
                break;
            case "sword":
                sword_level++;
                switch (sword_level)
                {
                    case 1:
                        Debug.Log("bat");
                        currentSword = bat;
                        break;
                    case 2:
                        Debug.Log("knife");
                        currentSword = knife;
                        break;
                }
                currentSword.damage += gameControllerScript.sword.damage.add;
                currentSword.speed += gameControllerScript.sword.fireRate.add;
                AttackRadius = currentSword.size;
                hpdamage = currentSword.damage;
                attackRate = currentSword.speed;
                break;
        }
    }

    public void Shoot()
    {
        GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CameraShake2>().Noise(3f, 3f);
        GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CameraShake2>().shoot = true;


        Quaternion rotation = firePoint.rotation;
        float dif = Random.value / (10 * currentGun.accuracy);

        if (Random.Range(0, 2) == 0)
        {
            rotation.z += dif;
        }
        else
        {
            rotation.z -= dif;
        }

        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, rotation);

        bullet.GetComponent<Bullet>().damage = currentGun.damage;
        bullet.GetComponent<Bullet>().speed = currentGun.bulletSpeed;

        gameControllerScript.gun.fire++;
        gameControllerScript.gun.fire_total++;
        gameControllerScript.checkFireRate(gameControllerScript.gun, "gun");

        if (gameControllerScript.gun.fire >= 10)
        {
            gameControllerScript.checkAccuracy(gameControllerScript.gun, "gun");
            gameControllerScript.gun.fire = 0;
            gameControllerScript.gun.hit = 0;
        }

        if (gameControllerScript.magic.fire >= 50)
        {
            gameControllerScript.checkAccuracy(gameControllerScript.magic, "magic");
            gameControllerScript.magic.fire = 0;
            gameControllerScript.magic.hit = 0;
        }

    }

    public void Attack()
    {

        Collider2D[] hitswordenemy = Physics2D.OverlapCircleAll(attackPoint.position, AttackRadius, SwordenemyLayer);

        foreach (Collider2D enemy in hitswordenemy)
        {
            gameControllerScript.sword.fire_total++;
            gameControllerScript.checkFireRate(gameControllerScript.sword, "sword");
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
                enemy.GetComponent<Enemy>().TakeDamage(hpdamage, "sword");
                //if(enemy.GetComponentInChildren<DamageBar>().damageDecrease==true)
                //enemy.GetComponentInChildren<DamageBar>().a = 0;
                //enemy.GetComponent<Enemy>().TakeDamage(hpdamage, attackposturedamage);
                CameraShaker.Instance.ShakeOnce(10f, 50f, .1f, 1f);
                Debug.Log("ATTACK SHAKE");
            }

            //ENEMY NORMAL HP DAMAGE

            else
            {
                enemy.GetComponent<Enemy>().TakeDamage(hpdamage, "sword");
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
                enemy.GetComponent<EnemyGunDying>().TakeDamage(hpdamage, "sword");
                CameraShaker.Instance.ShakeOnce(10f, 50f, .1f, 1f);
            }

            //GUN ENEMY NORMAL HP DAMAGE

            else
            {
                enemy.GetComponent<EnemyGunDying>().TakeDamage(hpdamage, "sword");
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

    void DeathblowBeforeAttack()
    {
        Collider2D[] hitswordenemy = Physics2D.OverlapCircleAll(attackPoint.position, AttackRadius, EnemiesLayer);

        foreach (Collider2D enemy in hitswordenemy)
        {
            if (deathblowSound)
            {
                Debug.Log("DeathBlow Sound");
                deathblowSound = false;
            }

            //GetComponentInChildren<SarpSwingsSword>().Deathblow();
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(DeflectPoint2.position, boyut);
        Gizmos.DrawSphere(attackPoint.position, AttackRadius);
    }
}