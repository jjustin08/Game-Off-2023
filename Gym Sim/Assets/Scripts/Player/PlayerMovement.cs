using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Animator animator;

    private float speed = 10;

    private Vector3 startingPos;

    private void Start()
    {
        startingPos = rb.transform.position;
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

        if (math.abs(force.x) > 0 || math.abs(force.z) > 0)
        {
            animator.Play("Walking");
        }
        else
        {
            animator.Play("Idle");
        }
    }

    private void LateUpdate()
    {
        if (rb.velocity != Vector3.zero)
        {
            
            Vector3 targetPosition = transform.position + rb.velocity;

            // Calculate the rotation that smoothly interpolates towards the target direction.
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);

            // Use Quaternion.Slerp to interpolate the rotation gradually.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);

        }


        //foreach (Rigidbody rigidbody in GetComponentsInChildren<Rigidbody>())
        //{
        //    rigidbody.velocity= rigidbody.velocity* 1 / 1.1f;
        //}
        rb.velocity= rb.velocity * 1/1.2f;

        //rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        //rb.transform.position = new Vector3(rb.transform.position.x, startingHeight, rb.transform.position.z);
    }
}
