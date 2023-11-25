using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private bool clicking;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        clicking = true;
    }

    private void OnMouseUp()
    {
        clicking = false;
        
    }

    private void Update()
    {
        FollowMouseWithVelocity();
    }

    private void FollowMouseWithVelocity()
    {
        if (!clicking)
        {
            rb.velocity /= 1.04f;
            return;
        }
            

        // magic number 2 is the height of floating cards
        Plane plane = new Plane(Vector3.forward, Vector3.one * -5);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float entry;
        Vector3 mouseWorldPos = Vector3.zero;
        if (plane.Raycast(ray, out entry))
        {

            mouseWorldPos =  ray.GetPoint(entry);
        }

        Vector3 newWorldPos = new Vector3(mouseWorldPos.x, mouseWorldPos.y, -5);

        Vector3 difference = newWorldPos - transform.position;

        rb.velocity = difference * 3;


    }
}
