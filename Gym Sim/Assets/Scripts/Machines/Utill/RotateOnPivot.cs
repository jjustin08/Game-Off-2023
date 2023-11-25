using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnPivot : MonoBehaviour
{

    [SerializeField] private Transform pivot;
    [SerializeField] private Transform pointer;
    [Range(0f, 1f)]
    [SerializeField] private float percentage;

    private float lastRotation = 0;
    private void Update()
    {
        // Rotate the pointer around the pivot
        RotatePointerByPercentage();
    }

    private void RotatePointerByPercentage()
    {
        if (pivot != null && pointer != null)
        {
            // Calculate the rotation angle based on the percentage
            //float minRotation = 0f;
            float maxRotation = 360f;
            float rotationAngle =  (maxRotation * percentage) ;
            if(lastRotation != rotationAngle) 
            {
                print("wtf");

                lastRotation = rotationAngle;

                // Calculate the rotation direction (clockwise or counterclockwise)
                Vector3 toPivot = pivot.position - pointer.position;
                float direction = Mathf.Sign(Vector3.Cross(pointer.up, toPivot).z);

                // Rotate the pointer around the pivot
                pointer.RotateAround(pivot.position, Vector3.forward, direction * rotationAngle);
                pointer.RotateAround(pivot.position, Vector3.forward, rotationAngle);
            }
           
        }
        else
        {
            Debug.LogWarning("Please assign the pivot and pointer in the inspector.");
        }
    }
}
