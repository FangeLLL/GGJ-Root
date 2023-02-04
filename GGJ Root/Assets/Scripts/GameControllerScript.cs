using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    public Combat combat;
    public int score,streak;
    public float streakTime;
    public TextMeshProUGUI scoreText,streakText;

    public class Spec
    {
        public float definer,barrier,add,start,amount;
        
    }

    public class Weapon
    {
        public float hit, fire, fire_total,kill,hit_total;
        public Spec fireRate = new Spec();
        public Spec damage = new Spec();
        public Spec accuracy = new Spec();
        public Spec upgrade = new Spec();
    }

    public Weapon sword = new Weapon();
    public Weapon magic = new Weapon();
    public Weapon gun = new Weapon();


    void Start()
    {
        gun.upgrade.barrier = 2;
        gun.fireRate.barrier = 5;
        gun.fireRate.amount = 0.5f;
        gun.accuracy.barrier = 0.15f;
        gun.accuracy.amount = 0.5f;
        gun.damage.barrier = 2;
        gun.damage.amount = 0.5f;

        magic.upgrade.barrier = 10;
        magic.fireRate.barrier = 100;
        magic.fireRate.amount = 0.5f;
        magic.accuracy.barrier = 0.15f;
        magic.accuracy.amount = 0.5f;
        magic.damage.barrier = 10;
        magic.damage.amount = 0.5f;

        sword.upgrade.barrier = 2;
        sword.fireRate.barrier = 5;
        sword.fireRate.amount = 0.5f;
        sword.damage.barrier = 3;
        sword.damage.amount = 0.5f;

        streak = 1;

    }

    private void Update()
    {
        if(streak !=1 && Time.time >= streakTime)
        {
            streak = 1;
            streakText.text = streak.ToString();
        }
    }

    public void checkAccuracy(Weapon weapon,string type)
    {
    
        if ((weapon.hit / weapon.fire) * weapon.accuracy.definer > weapon.accuracy.barrier)
        {
            Debug.Log("Accuracy incrased");

            weapon.accuracy.add += weapon.accuracy.amount;

            switch (type)
            {
                case "gun":

                    switch (weapon.accuracy.add / weapon.accuracy.amount)
                    {
                        case 1:
                            weapon.accuracy.barrier = 0.35f;
                            break;
                        case 2:
                            weapon.accuracy.barrier = 0.55f;
                            break;
                        case 3:
                            weapon.accuracy.barrier = 0.75f;
                            break;
                        case 4:
                            weapon.accuracy.barrier = 0.95f;
                            break;
                    }

                    combat.currentGun.accuracy += weapon.accuracy.amount;
                    Debug.Log(combat.currentGun.accuracy);

                    break;

                case "magic":

                    switch (weapon.accuracy.add / weapon.accuracy.amount)
                    {
                        case 1:
                            weapon.accuracy.barrier = 0.35f;
                            break;
                        case 2:
                            weapon.accuracy.barrier = 0.55f;
                            break;
                        case 3:
                            weapon.accuracy.barrier = 0.75f;
                            break;
                        case 4:
                            weapon.accuracy.barrier = 0.95f;
                            break;
                    }

                    // Change of gun accuracy 

                    //   combat.magic_accuracy +=weapon.accuracy.amount;

                    break;
            }

            //   combat.gainLevel();


        }
    }

    public void checkFireRate(Weapon weapon,string type)
    {
        if(weapon.fire_total >= weapon.fireRate.barrier)
        {
            Debug.Log("Fire Rate incrased");
            weapon.fireRate.add += weapon.fireRate.amount;

            switch (type)
            {
                case "gun":

                    switch (weapon.fireRate.add / weapon.fireRate.amount)
                    {
                        case 1:
                            weapon.fireRate.barrier = 15;
                            break;
                        case 2:
                            weapon.fireRate.barrier = 200;
                            break;
                        case 3:
                            weapon.fireRate.barrier = 250;
                            break;
                        case 4:
                            weapon.fireRate.barrier = 300;
                            break;
                    }
                    combat.currentGun.fireRate += weapon.fireRate.amount;
                    Debug.Log(combat.currentGun.fireRate);
                  
                    break;

                case "magic":

                    switch (weapon.fireRate.add / weapon.fireRate.amount)
                    {
                        case 1:
                            weapon.fireRate.barrier = 150;
                            break;
                        case 2:
                            weapon.fireRate.barrier = 200;
                            break;
                        case 3:
                            weapon.fireRate.barrier = 250;
                            break;
                        case 4:
                            weapon.fireRate.barrier = 300;
                            break;
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

                case "sword":

                    switch (weapon.fireRate.add / weapon.fireRate.amount)
                    {
                        case 1:
                            weapon.fireRate.barrier = 150;
                            break;
                        case 2:
                            weapon.fireRate.barrier = 200;
                            break;
                        case 3:
                            weapon.fireRate.barrier = 250;
                            break;
                        case 4:
                            weapon.fireRate.barrier = 300;
                            break;
                    }
                    combat.currentSword.speed += weapon.fireRate.amount;
                    Debug.Log(combat.currentSword.speed);
                    break;

            }
            //   combat.gainLevel();

        }
    }

    public void checkDamage(Weapon weapon,string type)
    {
        if (weapon.kill >= weapon.damage.barrier)
        {
            weapon.damage.add += weapon.damage.amount;

            Debug.Log("Damage incrased");

            switch (type)
            {
                case "gun":

                    switch (weapon.damage.add / weapon.damage.amount)
                    {
                        case 1:
                            weapon.damage.barrier = 4;
                            break;
                        case 2:
                            weapon.damage.barrier = 20;
                            break;
                        case 3:
                            weapon.damage.barrier = 25;
                            break;
                        case 4:
                            weapon.damage.barrier = 30;
                            break;
                    }

                       combat.currentGun.damage += weapon.damage.amount;
                      Debug.Log(combat.currentGun.damage);
                    break;

                case "magic":

                    switch (weapon.damage.add / weapon.damage.amount)
                    {
                        case 1:
                            weapon.damage.barrier = 15;
                            break;
                        case 2:
                            weapon.damage.barrier = 20;
                            break;
                        case 3:
                            weapon.damage.barrier = 25;
                            break;
                        case 4:
                            weapon.damage.barrier = 30;
                            break;
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

                case "sword":

                    switch (weapon.damage.add / weapon.damage.amount)
                    {
                        case 1:
                            weapon.damage.barrier = 15;
                            break;
                        case 2:
                            weapon.damage.barrier = 20;
                            break;
                        case 3:
                            weapon.damage.barrier = 25;
                            break;
                        case 4:
                            weapon.damage.barrier = 30;
                            break;
                    }
                    combat.currentSword.damage += weapon.damage.amount;
                    Debug.Log(combat.currentSword.damage);
                    break;

            }
            //   combat.gainLevel();

        }
    }

    public void checkWeaponLevel(Weapon weapon, string type)
    {
        if (weapon.kill >= weapon.upgrade.barrier)
        {
            switch (type)
            {
                case "gun":

                    combat.levelUpWeapon("gun");

                    switch (combat.gun_level)
                    {
                        case 1:
                            weapon.upgrade.barrier = 5;
                            break;
                        case 2:
                            weapon.upgrade.barrier = 20;
                            break;
                     
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

                case "magic":

                    combat.levelUpWeapon("magic");

                    switch (combat.magic_level)
                    {
                        case 1:
                            weapon.upgrade.barrier = 15;
                            break;
                        case 2:
                            weapon.upgrade.barrier = 20;
                            break;
                       
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

                case "sword":

                    combat.levelUpWeapon("sword");

                    switch (combat.sword_level)
                    {
                        case 1:
                            weapon.upgrade.barrier = 4;
                            break;
                        case 2:
                            weapon.upgrade.barrier = 20;
                            break;
 
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

            }
            //   combat.gainLevel();

        }
    }

    IEnumerator textAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        scoreText.color = Color.white;
        scoreText.fontSize=36;
    }

    public void checkScore()
    {
        scoreText.text = score.ToString();
        scoreText.color = Color.red;
        scoreText.fontSize=45;
        streakTime = Time.time + 2f;
        streak++;
        streakText.text = (streak-1).ToString();
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

    }

    private void SpecStartSetting(Spec spec)
    {
        if (spec.barrier>spec.start)
        {
            spec.start += spec.amount;
            spec.barrier = spec.start;
        }
    }
}
