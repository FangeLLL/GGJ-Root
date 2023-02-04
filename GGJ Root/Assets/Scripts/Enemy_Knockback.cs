using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{
    public GameObject Player;

    public float knockbackTime = 0.5f;
    public Vector2 knockbackDirection = new Vector2(0f, 0.8f);
    private Vector2 startPos;

    //int parametreattackBool = Animator.StringToHash("attackBool");
    //int parametrewalkBool = Animator.StringToHash("walkBool");

    public void Knockback()
    {
        knockbackDirection = new Vector2(0f, GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>().hpdamage * 0.16f);
        Vector2 direction = (Player.transform.position - transform.position).normalized;
        knockbackDirection = direction * knockbackDirection.magnitude;
        StartCoroutine(KnockbackCoroutine());

        //AI CLOSE

        /*GetComponent<SwordEnemyAI>().stoppingIEnumerators();
        GetComponent<SwordEnemyAI>().enabled = false;
        anim.SetBool(parametreattackBool, false);*/

        //AI CLOSE

        /*GetComponent<AIDestinationSetter>().enabled = false;
        GetComponent<EnemyLookDirSword>().enabled = false;
        GetComponent<AIPath>().enabled = false;*/
    }

    IEnumerator KnockbackTime()
    {
        yield return new WaitForSeconds(.30f);

        /*if (this.GetComponent<EnemyStun>().knockbackchecker == false)
        {
            GetComponent<AIDestinationSetter>().enabled = true;
            GetComponent<SwordEnemyAI>().enabled = true;
            EnemyLeg.GetComponent<Animator>().enabled = true;
            EnemyLeg.GetComponent<Renderer>().enabled = true;
            GetComponent<EnemyLookDirSword>().enabled = true;
            GetComponent<AIPath>().enabled = true;
        }*/

        knockbackDirection = new Vector2(0f, 0.8f);
    }

    private IEnumerator KnockbackCoroutine()
    {
        startPos = transform.position;
        Vector2 endPos = startPos - knockbackDirection;
        float elapsedTime = 0f;

        while (elapsedTime < knockbackTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos, elapsedTime / knockbackTime);
            yield return null;
        }
    }

    /*private void Update()
    {
        if (Player.GetComponent<Combat>().enhancedKatana == true || Player.GetComponent<Combat>().chargedKatana == true)
            storedHpDamage = Player.GetComponent<Combat>().hpdamage;
        else
        {
            if (storedHpDamage != 5)
                storedHpDamage = 5;
        }
    }*/
}