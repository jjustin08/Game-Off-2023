using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private float speed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 direction = Vector3.zero;
        if(Input.GetKey(KeyCode.A))
        {
            direction.x = 1;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            direction.x = -1;
        }
        if(Input.GetKey(KeyCode.W))
        {
            direction.z = -1;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            direction.z = 1;
        }

        Vector3 force = direction.normalized* speed;

        rb.AddForce(force);
    }

    private void LateUpdate()
    {
        if(rb.velocity != Vector3.zero) 
        {
            Vector3 targetPosition = transform.position + rb.velocity;

            // Calculate the rotation that smoothly interpolates towards the target direction.
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);

            // Use Quaternion.Slerp to interpolate the rotation gradually.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);

        }

        rb.velocity= rb.velocity * 1/1.1f;
    }
}
