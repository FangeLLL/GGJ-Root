using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using EZCameraShake;

public class Bullet : MonoBehaviour
{
    //[SerializeField] CinemachineVirtualCamera vcam;
    //CinemachineBasicMultiChannelPerlin noise;


    public GameObject shake;

    public float speed, duration = 5f, deathTime;
    public Rigidbody2D rb;
    public float damage;
    void Start()
    {
        deathTime = Time.time + duration;
        rb.velocity = transform.up * speed;
        rb=GetComponent<Rigidbody2D>();
        //vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        //noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
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
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage, "gun");
                break;
            case "GunEnemy":
                collision.gameObject.GetComponent<EnemyGunDying>().TakeDamage(damage, "gun");
                break;
            case "Player":
                //PLAYER DAMAGE
                Debug.Log("Player Die Gun Enemy");
                //CinemachineShake.Instance.ShakeCamera(4f, 4f, 2f);
                break;
        }

        Destroy(gameObject);
    }

}