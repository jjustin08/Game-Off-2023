using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGameCurved : MonoBehaviour
{
    public Bicep bicep;

    [SerializeField] private Image targetMax;
    [SerializeField] private Image targetMin;

    [SerializeField] private RectTransform pointer;
    [SerializeField] private Transform pointerPin;

    [SerializeField] private bool isRight;

    private float targetSize = 30f;

    float currentRotation = 90.0f;

    float rotationSpeed = 0.6f;

    float minRotation = -90.0f;
    float maxRotation = 90.0f;

    private bool isActive = false;



    private void Awake()
    {
        if (isRight)
        {
            rotationSpeed *= -1;
        }
        if (!isRight)
        {
            currentRotation = 90;
            minRotation = 90;
            maxRotation = 270;
        }
    }
    public void Activate()
    {
        isActive = true;

        
    }
    private void Update()
    {
        if(isActive)
        {
            Controls();
            GameUpdate();
        }
    }

    private void GameUpdate()
    {
        // Calculate the new rotation angle based on the current angle and direction
        float newRotation = currentRotation + rotationSpeed;

        if (newRotation > maxRotation)
        {
            // Reverse the rotation direction
            rotationSpeed *= -1;
            if (isRight)
            {
                isActive = false;
            }
        }
        else if(newRotation < minRotation)
        {
            rotationSpeed *= -1;
            if(!isRight)
            {
                isActive = false;
            }
            
        }

        // Update the current rotation angle
        currentRotation += rotationSpeed;

        // Apply the rotation
        pointer.RotateAround(pointerPin.position, new Vector3(0, 0, 1), rotationSpeed);

        
    }


    private void Controls()
    {
        if (isRight)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CheckIfInside();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckIfInside();
            }
        }

    }



    private void CheckIfInside()
    {
        float progress = CalculateRotationPercentage();

        float max = targetMax.fillAmount * 100;
        float min = targetMin.fillAmount * 100;

        //print("min: " + min);
        //print("roation: " + progress);
        //print("max: " + max);


        if (progress >= min && progress <= max)
        {
            HitTarget();

        }
        else
        {
            bicep.AddMiss();
            //MissTarget();
        }
    }

    private float CalculateRotationPercentage()
    {
        float mappedRotation = currentRotation - minRotation;

        float percentage = (mappedRotation / (maxRotation - minRotation)) * 100.0f;


        if(!isRight)
        {
            percentage = 100 - percentage;
        }
        return percentage;
    }

    private void HitTarget()
    {


        // decreasing size of target
        if ((targetSize = targetSize / 1.2f) >= 1)
        {
            if (bicep != null)
            {
                bicep.AddGain();
            }
            ChangeTargetLocation(targetSize);
        }
        else
        {
            if (bicep != null)
            {
                bicep.GameOver();
            }
            //game over??
        }


    }

    //private void MissTarget()
    //{
    //    if ((targetSize = targetSize / 1.2f) >= 5)
    //    {
    //        ChangeTargetLocation(targetSize);
    //    }
    //    else
    //    {
    //        //game over??
    //    }
    //}







    void ChangeTargetLocation(float size)
    {
        float randomRotation = 0;
        if (targetMin.fillAmount >= 0.5)
        {
            randomRotation = UnityEngine.Random.Range(20, 50);
        }
        else
        {
            randomRotation = UnityEngine.Random.Range(50, 80);
        }

        randomRotation /= 100;

        targetMin.fillAmount = randomRotation;
        targetMax.fillAmount = randomRotation + (size/ 100);
    }
}
