using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float attackDistance;
    public float attackRadius = .5f;
    public bool a;
    public bool oneTimeExecution;

    public Transform player;
    public Transform attackPoint;

    public LayerMask playerLayer;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        oneTimeExecution = true;
        a = true;
    }

    private void OnEnable()
    {
        oneTimeExecution = true;
        a = true;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) < attackDistance)
        {
            //MAIN ATTACK STUFF
            if (oneTimeExecution)
            {
                a = true;
                MainAttack();
                oneTimeExecution = false;
            }
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        /*else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }*/
    }

    void MainAttack()
    {
        if (a)
        {
            //SWORD SWING SOUND EFFECT
            //swordSwing.GetComponent<EnemyDeathSoundRandomizer>().CallEnemyIEnumerator();
            //ENEMY ATTACK ANIMATION
            //anim.SetBool(parametreattackBool, true);
            StartCoroutine(DeflectTimeThenAttack());
        }
    }

    void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            //PLAYER DIE
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDie>().DeathbySwordEnemy();
            Debug.Log("Player Die");
        }
    }

    IEnumerator DeflectTimeThenAttack()
    {
        //ENEMY ATTACK ANIMATION
        //anim.SetBool(parametreattackBool, false);
        yield return new WaitForSeconds(.2f);
        yield return null;
        Attack();
        yield return new WaitForSeconds(.27f);
        StartCoroutine(NextAttackDelay());
    }

    IEnumerator NextAttackDelay()
    {
        yield return new WaitForSeconds(1);
        oneTimeExecution = true;
        a = false;
    }

}
