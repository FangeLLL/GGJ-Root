using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public Combat combat;

    public class Spec
    {
        public float definer, barrier,add,start,amount;
    }

    public class Weapon
    {
        public int hit, fire, fire_total,kill;
        public Spec fireRate = new Spec();
        public Spec damage = new Spec();
        public Spec accuracy = new Spec();

    }

    public Weapon sword = new Weapon();
    public Weapon magic = new Weapon();
    public Weapon gun = new Weapon();


    void Start()
    {
        gun.fireRate.barrier = 100;
        gun.fireRate.amount = 0.5f;
        gun.accuracy.barrier = 0.15f;
        gun.accuracy.amount = 0.5f;
        gun.damage.barrier = 10;
        gun.damage.amount = 0.5f;

        magic.fireRate.barrier = 100;
        magic.fireRate.amount = 0.5f;
        magic.accuracy.barrier = 0.15f;
        magic.accuracy.amount = 0.5f;
        magic.damage.barrier = 10;
        magic.damage.amount = 0.5f;

        sword.fireRate.barrier = 100;
        sword.fireRate.amount = 0.5f;
        sword.damage.barrier = 10;
        sword.damage.amount = 0.5f;

    }

    void Update()
    {
        if (gun.fire >= 100)
        {
            checkAccuracy(gun);
            gun.fire = 0;
            gun.hit = 0;
        }

        if (magic.fire >= 50)
        {
            checkAccuracy(magic);
            magic.fire = 0;
            magic.hit = 0;
        }

        checkFireRate(gun);
        checkFireRate(magic);
        checkFireRate(sword);

        checkDamage(gun);
        checkDamage(magic);
        checkDamage(sword);

    }

    private void checkAccuracy(Weapon weapon)
    {
        if (weapon.hit / weapon.fire * weapon.accuracy.definer > weapon.accuracy.barrier)
        {
            weapon.accuracy.add += weapon.accuracy.amount;

            switch (weapon)
            {
                case gun:

                    switch (weapon.accuracy.add / weapon.accuracy.amount)
                    {
                        case 1:
                            weapon.accuracy.barrier = 0.35f
                            break;
                        case 2:
                            weapon.accuracy.barrier = 0.55f
                            break;
                        case 3:
                            weapon.accuracy.barrier = 0.75f
                            break;
                        case 4:
                            weapon.accuracy.barrier = 0.95f
                            break;
                    }

                    // Change of gun accuracy 

                    //   combat.gun_accuracy += weapon.accuracy.amount;

                    break;

                case magic:

                    switch (weapon.accuracy.add / weapon.accuracy.amount)
                    {
                        case 1:
                            weapon.accuracy.barrier = 0.35f
                            break;
                        case 2:
                            weapon.accuracy.barrier = 0.55f
                            break;
                        case 3:
                            weapon.accuracy.barrier = 0.75f
                            break;
                        case 4:
                            weapon.accuracy.barrier = 0.95f
                            break;
                    }

                    // Change of gun accuracy 

                    //   combat.magic_accuracy +=weapon.accuracy.amount;

                    break;
            }

            //   combat.gainLevel();


        }
    }

    private void checkFireRate(Weapon weapon)
    {
        if(weapon.fire_total >= weapon.fireRate.barrier)
        {
            weapon.fireRate.add += weapon.fireRate.amount;

            switch (weapon)
            {
                case gun:

                    switch (weapon.fireRate.add / weapon.fireRate.amount)
                    {
                        case 1:
                            weapon.fireRate.barrier = 150
                            break;
                        case 2:
                            weapon.fireRate.barrier = 200
                            break;
                        case 3:
                            weapon.fireRate.barrier = 250
                            break;
                        case 4:
                            weapon.fireRate.barrier = 300
                            break;
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

                case magic:

                    switch (weapon.fireRate.add / weapon.fireRate.amount)
                    {
                        case 1:
                            weapon.fireRate.barrier = 150
                            break;
                        case 2:
                            weapon.fireRate.barrier = 200
                            break;
                        case 3:
                            weapon.fireRate.barrier = 250
                            break;
                        case 4:
                            weapon.fireRate.barrier = 300
                            break;
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

                case sword:

                    switch (weapon.fireRate.add / weapon.fireRate.amount)
                    {
                        case 1:
                            weapon.fireRate.barrier = 150
                            break;
                        case 2:
                            weapon.fireRate.barrier = 200
                            break;
                        case 3:
                            weapon.fireRate.barrier = 250
                            break;
                        case 4:
                            weapon.fireRate.barrier = 300
                            break;
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

            }
            //   combat.gainLevel();

        }
    }

    private void checkDamage(Weapon weapon)
    {
        if (weapon.kill >= weapon.damage.barrier)
        {
            weapon.damage.add += weapon.damage.amount;

            switch (weapon)
            {
                case gun:

                    switch (weapon.damage.add / weapon.damage.amount)
                    {
                        case 1:
                            weapon.damage.barrier = 15
                            break;
                        case 2:
                            weapon.damage.barrier = 20
                            break;
                        case 3:
                            weapon.damage.barrier = 25
                            break;
                        case 4:
                            weapon.damage.barrier = 30
                            break;
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

                case magic:

                    switch (weapon.damage.add / weapon.damage.amount)
                    {
                        case 1:
                            weapon.damage.barrier = 15
                            break;
                        case 2:
                            weapon.damage.barrier = 20
                            break;
                        case 3:
                            weapon.damage.barrier = 25
                            break;
                        case 4:
                            weapon.damage.barrier = 30
                            break;
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

                case sword:

                    switch (weapon.damage.add / weapon.damage.amount)
                    {
                        case 1:
                            weapon.damage.barrier = 15
                            break;
                        case 2:
                            weapon.damage.barrier = 20
                            break;
                        case 3:
                            weapon.damage.barrier = 25
                            break;
                        case 4:
                            weapon.damage.barrier = 30
                            break;
                    }
                    // Change of weapon firerate

                    //   combat.gun_fireRate += 0.5f;
                    break;

            }
            //   combat.gainLevel();

        }
    }


}
