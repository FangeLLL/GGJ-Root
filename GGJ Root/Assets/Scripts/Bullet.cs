using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5f, duration = 5f, deathTime;
    public Rigidbody2D rb;
    public float damage = 5f;
    void Start()
    {
        speed = 5f;
        deathTime = Time.time + duration;
        rb.velocity = transform.up * speed;
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.time > deathTime)
        {
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
            case "Player":
                //PLAYER DAMAGE
                Debug.Log("Player Die Gun Enemy");
                break;
        }

        Destroy(gameObject);
    }

}