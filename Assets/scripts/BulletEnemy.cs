using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float life = 3f;
    public AttributesManager enemyAtm;
    public AttributesManager playerAtm;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player")) // Check if the collided object has a specific tag
        {
            enemyAtm.DealDamage(playerAtm.gameObject);
            Debug.Log("vuruldukkh");
            if(playerAtm.health <= 0)
            {
                playerAtm.health = 0;
                playerAtm.health = playerAtm.maxHealth;
                Destroy(collision.gameObject); // Destroy the collided object

                Destroy(gameObject);
            }
            

        }
        //Destroy(collision.gameObject);


    }
}