using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

<<<<<<< Updated upstream
    public float speed = 5f, duration = 5f, deathTime;
=======
    public float speed = 5f,duration=5f,deathTime;
>>>>>>> Stashed changes
    public Rigidbody2D rb;
    public float damage = 5f;
    void Start()
    {
        speed = 5f;
        deathTime = Time.time + duration;
        rb.velocity = transform.up * speed;
<<<<<<< Updated upstream
        rb=GetComponent<Rigidbody2D>();
=======
        
>>>>>>> Stashed changes
    }

    void Update()
    {
<<<<<<< Updated upstream
        if (Time.time > deathTime)
        {
=======
        if(Time.time > deathTime) {
>>>>>>> Stashed changes
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "SwordEnemy":
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                break;
            case "GunEnemy":
                collision.gameObject.GetComponent<EnemyGunDying>().TakeDamage(damage);
                break;
<<<<<<< Updated upstream
            case "Player":
                //PLAYER DAMAGE
                Debug.Log("Player Die Gun Enemy");
                break;
=======
>>>>>>> Stashed changes
        }

        Destroy(gameObject);
    }

<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
