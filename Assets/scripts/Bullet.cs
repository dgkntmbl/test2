using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;

    void Awake()
    {
        Destroy(gameObject,life);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy")) // Check if the collided object has a specific tag
        {
            
            Destroy(collision.gameObject); // Destroy the collided object

            Destroy(gameObject);
            
        }
        //Destroy(collision.gameObject);

        
    }
}
