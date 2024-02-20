using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    public Rigidbody rb;
    public Transform player;
    private Vector3 movement;
    public float moveSpeed = 3f;

    
    void Start()
    {
        player = FindObjectOfType<playerMove>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        transform.LookAt(player.transform);

        rb.AddForce(moveSpeed * Time.deltaTime * transform.forward);
        direction.Normalize();
        movement = direction;

     
    }

    
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position+ (direction* moveSpeed *Time.deltaTime));
    }
}
