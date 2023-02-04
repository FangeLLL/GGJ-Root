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

    public float speed = 5f, duration = 5f, deathTime;
    public Rigidbody2D rb;
    public float damage = 5f;
    void Start()
    {
        speed = 5f;
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
                if (collision.gameObject.GetComponent<Enemy>().CurrentHealt <= GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().hpdamage)
                {
                    CameraShaker.Instance.ShakeOnce(10f, 50f, .1f, 1f);
                }                                        
                break;
            case "GunEnemy":
                collision.gameObject.GetComponent<EnemyGunDying>().TakeDamage(damage, "gun");

                if (collision.gameObject.GetComponent<EnemyGunDying>().CurrentHealt <= GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().hpdamage)
                {
                    CameraShaker.Instance.ShakeOnce(10f, 50f, .1f, 1f);
                }

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