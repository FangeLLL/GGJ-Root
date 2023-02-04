using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBar : MonoBehaviour
{
    public Slider damageSlider;
    public HealthBar healthBar;
    public bool damageDecrease;
    public float a;

    public void SetDamageBar(float startingHealth)
    {        
        damageSlider.maxValue = startingHealth;
        damageSlider.value = startingHealth;
    }

    /*public void TakeDamage2(float damage)
    {
        //StopAllCoroutines();
        //a = a + damage;
    }*/

    public void SJ()
    {
        StartCoroutine(atrue());
    }

    public IEnumerator atrue()
    {
        yield return new WaitForSeconds(1);
        damageDecrease = true;
    }

    void Update()
    {
        if (damageDecrease)
        {
            if (damageSlider.value == healthBar.slider.value)
            {
                damageDecrease = false;
                a = 0;
            }
            else
            {
                damageSlider.value = Mathf.Lerp(damageSlider.value, healthBar.slider.value, a / .15f);
                a += Time.deltaTime;
            }                          
        }
    }
}
