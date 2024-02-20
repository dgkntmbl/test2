using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

   
    
    void OnCollisionStay(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Enemy")
        {
            
        }
    }

}
