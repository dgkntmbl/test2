using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public float maxHealth = 50f;
    public float enemyMaxHealth = 30f;
    public float health;
    public float enemyHealth;
    public float attack;


    void Start()
    {
        health = maxHealth;
        enemyHealth = enemyMaxHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if(atm != null )
        {
            atm.TakeDamage(attack);
        }
    }

}
