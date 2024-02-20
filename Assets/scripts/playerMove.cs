using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5;
    public float turnSpeed = 360;
    public Vector3 input_;
    public float moveSpeed = 5f;
    void Update()
    {
        GatherInput();
        Look();

    }

    void FixedUpdate()
    {

        Move();
    }
    void GatherInput()
    {
        input_ = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    }

    void Look()
    {
        if (input_ != Vector3.zero)
        {
            // private static Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            // public static Vector3 ToIso(this Vector3 input) => isoMatrix.MultiplyPoint3x4(input);

            var relative = (transform.position + input_.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }

    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * input_.magnitude) * moveSpeed * Time.deltaTime); //characterdata.movespeed yerine speed vardý sadece
    }
}
