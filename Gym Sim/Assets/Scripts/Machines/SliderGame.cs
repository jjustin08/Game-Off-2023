using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class SliderGame : MonoBehaviour
{
    private UnityEngine.UI.Slider slider;

    [SerializeField] private RectTransform target;
    [SerializeField] private RectTransform container;

    private float bufferSpace = 10f;
    private float targetSize = 100f;

    private void Awake()
    {
        slider = GetComponent<UnityEngine.UI.Slider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CheckIfInside();
        }

    }
    private void CheckIfInside()
    {
        float progress = slider.value;

        float xMin = CalculateXPercentage(container, target.anchoredPosition.x - target.sizeDelta.x /2);
        float xMax = CalculateXPercentage(container, target.anchoredPosition.x + target.sizeDelta.x /2);

      
        if (progress >= xMin && progress <= xMax)
        {
            HitTarget();
        }
        else
        {
            MissTarget();
        }
    }

    float CalculateXPercentage(RectTransform rectTransform, float xPosition)
    {
        
        float leftBoundary = rectTransform.anchoredPosition.x - (rectTransform.sizeDelta.x / 2f);
        float width = rectTransform.sizeDelta.x;

        float percentage = ((xPosition - leftBoundary) / width) * 100f;

        return percentage/ 100; // Clamp to the range [0, 100]
    }

    private void HitTarget()
    {
        if((targetSize = targetSize / 1.5f) >= 5)
        {
            ChangeTargetLocation(targetSize);
        }
        else
        {
            //game over??
        }

       
    }

    private void MissTarget()
    {
        if ((targetSize = targetSize / 1.2f) >= 5)
        {
            ChangeTargetLocation(targetSize);
        }
        else
        {
            //game over??
        }
    }
   

   

    private void ChangeTargetLocation(float size)
    {
        ChangeWidthOfRectTransform(size);
        SetRandomXPosition();
    }

    void ChangeWidthOfRectTransform(float newWidth)
    {
        Vector2 sizeDelta = target.sizeDelta;
        sizeDelta.x = newWidth;
        target.sizeDelta = sizeDelta;
    }

    void SetRandomXPosition()
    {
        Vector2 containerSize = container.sizeDelta;

        // Get the size of the target RectTransform
        Vector2 targetSize = target.sizeDelta;

        // Calculate the valid range for the target RectTransform along the x-axis within the container
        float xMin = -(containerSize.x / 2) + (targetSize.x / 2) + (bufferSpace * 2);
        float xMax = (containerSize.x / 2) - (targetSize.x / 2) - bufferSpace;

        // Generate a random position along the x-axis within the valid range
        float randomX = UnityEngine.Random.Range(xMin, xMax);

        // Set the anchored position of the target RectTransform to the random x-position
        Vector2 anchoredPosition = target.anchoredPosition;
        anchoredPosition.x = randomX;
        target.anchoredPosition = anchoredPosition;



    }


}
