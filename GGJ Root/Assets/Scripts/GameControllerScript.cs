using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    public Combat combat;
    public int score, streak;
    public float streakTime;
    public TextMeshProUGUI scoreText, streakText;
    public WaveSystem waveSystem;
    private GameObject[] enemies;
    public List<string> PowerUps = new List<string>() { "Magic", "Gun" };


    public class Spec
    {
        public float definer, currentBarrier, add = 0, start = 0, amount;
        public float[] barriers;
        public Spec(float[] barr)
        {
            barriers = barr;
            currentBarrier = barr[0];
        }

    }

    public class Weapon
    {
        public float hit, fire, fire_total = 0, kill = 0, hit_total = 0;
        public Spec fireRate;
        public Spec damage;
        public Spec accuracy;
        public Spec upgrade;
        public Weapon(float[] fireRateB, float[] damageB, float[] accuracyB, float[] upgradeB)
        {
            fireRate = new Spec(fireRateB);
            damage = new Spec(damageB);
            accuracy = new Spec(accuracyB);
            upgrade = new Spec(upgradeB);
        }
    }

    public Weapon sword = new Weapon(new float[] { 0, 10, 20, 25, 30 }, new float[] { 0, 10, 20, 25, 30 }, new float[] { 0, 0.10f, 0.20f, 0.25f, 0.30f }, new float[] { 0, 10, 20, 25, 30 });
    public Weapon magic = new Weapon(new float[] { 0, 10, 20, 25, 30 }, new float[] { 0, 10, 20, 25, 30 }, new float[] { 0, 0.10f, 0.20f, 0.25f, 0.30f }, new float[] { 0, 10, 20, 25, 30 });
    public Weapon gun = new Weapon(new float[] { 0, 10, 20, 25, 30 }, new float[] { 0, 10, 20, 25, 30 }, new float[] { 0, 0.10f, 0.20f, 0.25f, 0.30f }, new float[] { 0, 10, 20, 25, 30 });


    void Start()
    {
        gun.fireRate.amount = 0.5f;
        gun.accuracy.amount = 0.5f;
        gun.damage.amount = 0.5f;
        gun.upgrade.amount = 0.5f;

        magic.fireRate.amount = 0.5f;
        magic.accuracy.amount = 0.5f;
        magic.damage.amount = 0.5f;
        magic.upgrade.amount = 0.5f;

        sword.fireRate.amount = 0.5f;
        sword.damage.amount = 0.5f;
        sword.upgrade.amount = 0.5f;

        streak = 1;

    }

    private void Update()
    {
        if (streak != 1 && Time.time >= streakTime)
        {
            streak = 1;
            streakText.text = streak.ToString();
        }
    }

    public void checkAccuracy(Weapon weapon, string type)
    {
        if (weapon.accuracy.barriers[weapon.accuracy.barriers.Length - 1] != weapon.accuracy.currentBarrier)
        {
            //   if ((weapon.hit / weapon.fire) * weapon.accuracy.definer > weapon.accuracy.currentBarrier)
            if ((weapon.hit_total / weapon.fire_total) > weapon.accuracy.currentBarrier)
            {
                Debug.Log("Accuracy incrased");

                weapon.accuracy.add += weapon.accuracy.amount;

                weapon.accuracy.currentBarrier = weapon.accuracy.barriers[(int)(weapon.accuracy.add / weapon.accuracy.amount)];

                switch (type)
                {
                    case "gun":

                        combat.currentGun.accuracy += weapon.accuracy.amount;
                        Debug.Log(combat.currentGun.accuracy);

                        break;

                    case "magic":


                        // Change of gun accuracy 

                        //   combat.magic_accuracy +=weapon.accuracy.amount;

                        break;
                }

                //   combat.gainLevel();


            }
        }


    }

    public void checkFireRate(Weapon weapon, string type)
    {
        if (weapon.fireRate.barriers[weapon.fireRate.barriers.Length - 1] != weapon.fireRate.currentBarrier)
        {
            if (weapon.fire_total >= weapon.fireRate.currentBarrier)
            {
                weapon.fireRate.add += weapon.fireRate.amount;
                weapon.fireRate.currentBarrier = weapon.fireRate.barriers[(int)(weapon.fireRate.add / weapon.fireRate.amount)];


                switch (type)
                {
                    case "gun":

                        combat.currentGun.fireRate += weapon.fireRate.amount;
                        Debug.Log(combat.currentGun.fireRate);

                        break;

                    case "magic":


                        break;

                    case "sword":

                        combat.currentSword.speed += weapon.fireRate.amount;
                        Debug.Log(combat.currentSword.speed);
                        break;

                }

            }
        }
        else
        {
            Debug.Log("MAX");
        }

    }

    public void checkDamage(Weapon weapon, string type)
    {
        if (weapon.damage.barriers[weapon.damage.barriers.Length - 1] != weapon.damage.currentBarrier)
        {
            if (weapon.kill >= weapon.damage.currentBarrier)
            {
                weapon.damage.add += weapon.damage.amount;

                weapon.damage.currentBarrier = weapon.damage.barriers[(int)(weapon.damage.add / weapon.damage.amount)];

                Debug.Log("Damage incrased");

                switch (type)
                {
                    case "gun":

                        combat.currentGun.damage += weapon.damage.amount;
                        Debug.Log(combat.currentGun.damage);
                        break;

                    case "magic":

                        // Change of weapon firerate

                        //   combat.gun_fireRate += 0.5f;
                        break;

                    case "sword":


                        combat.currentSword.damage += weapon.damage.amount;
                        Debug.Log(combat.currentSword.damage);
                        break;

                }
                //   combat.gainLevel();

            }
        }
    }

    public void checkWeaponLevel(Weapon weapon, string type)
    {
        if (weapon.upgrade.barriers[weapon.upgrade.barriers.Length - 1] != weapon.upgrade.currentBarrier)
        {
            if (weapon.kill >= weapon.upgrade.currentBarrier)
            {
                weapon.upgrade.currentBarrier = weapon.upgrade.barriers[(int)(weapon.upgrade.add / weapon.upgrade.amount)];
                switch (type)
                {
                    case "gun":

                        combat.levelUpWeapon("gun");

                        // Change of weapon firerate

                        //   combat.gun_fireRate += 0.5f;
                        break;

                    case "magic":

                        combat.levelUpWeapon("magic");

                        // Change of weapon firerate

                        //   combat.gun_fireRate += 0.5f;
                        break;

                    case "sword":

                        combat.levelUpWeapon("sword");

                        // Change of weapon firerate

                        //   combat.gun_fireRate += 0.5f;
                        break;

                }
                //   combat.gainLevel();
            }
        }
    }

    IEnumerator textAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        scoreText.color = Color.white;
        scoreText.fontSize = 36;
    }

    public void checkScore()
    {
        scoreText.text = score.ToString();
        scoreText.color = Color.red;
        scoreText.fontSize = 45;
        streakTime = Time.time + 2f;
        streak++;
        streakText.text = (streak - 1).ToString();
        StartCoroutine(textAnimation());

    }

    public void Inheritance()
    {
        SpecStartSetting(gun.accuracy);
        SpecStartSetting(gun.fireRate);
        SpecStartSetting(gun.damage);

        SpecStartSetting(magic.accuracy);
        SpecStartSetting(magic.fireRate);
        SpecStartSetting(magic.damage);

        SpecStartSetting(sword.fireRate);
        SpecStartSetting(sword.damage);

        ResetIstatistics(gun);
        ResetIstatistics(magic);
        ResetIstatistics(sword);

        score = 0;
        streak = 0;
        waveSystem.level = 1;
        waveSystem.totalEnemy = 0;
    }

    private void SpecStartSetting(Spec spec)
    {
        if (spec.currentBarrier > spec.barriers[System.Array.IndexOf(spec.barriers, spec.start) + 1])
        {
            spec.start = spec.barriers[System.Array.IndexOf(spec.barriers, spec.start) + 1];
            spec.currentBarrier = spec.start;
            spec.add = System.Array.IndexOf(spec.barriers, spec.start) * spec.amount;
            Debug.Log(spec.start);
            Debug.Log(spec.add);

        }
    }

    public void resetScene()
    {
        DestroyTagObjects("GunEnemy");
        DestroyTagObjects("SwordEnemy");
        DestroyTagObjects("Buff");
        DestroyTagObjects("Bullet");
    }

    private void ResetIstatistics(Weapon weapon)
    {
        weapon.kill = 0;
        weapon.hit = 0;
        weapon.fire = 0;
        weapon.hit_total = 0;
        weapon.fire_total = 0;
    }

    private void DestroyTagObjects(string tag)
    {
        enemies = GameObject.FindGameObjectsWithTag(tag);

        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }

    }

   
}
