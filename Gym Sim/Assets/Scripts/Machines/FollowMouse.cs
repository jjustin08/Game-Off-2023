using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private bool clicking;

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
        if (clicking)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
            Vector3 newPos = Camera.main.ScreenToWorldPoint(mousePos);

            newPos.z = 0;

            transform.position = Vector3.Slerp(transform.position, newPos, 3 * Time.deltaTime);
        }
    }
}
