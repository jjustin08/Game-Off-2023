using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Bicep : BaseMachine
{
    [SerializeField] private Transform weight;
    [SerializeField] private UnityEngine.UI.Slider slider;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private float moveSpeed = 1.0f;

    private float progress = 0f;


    private float targetMax = 0.7f;
    private float targetMin = 0.5f;
    private bool isRunning = false;



    private void Update()
    {
        if (isActive)
        {
            Controls();
            MachineUpdate();
        }
        else
        {
            isRunning = false;
        }
    }

    private void MachineUpdate()
    {
        if(isRunning)
        {
            
            float t = Mathf.PingPong(Time.time * moveSpeed, 1.0f);
            progress = t;
            slider.value = progress;
            weight.position = Vector3.Lerp(startPos.position, endPos.position, t);
            
        }
    }


    private void Controls()
    {
       if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            if(!isRunning)
            {
                isRunning= true;
            }
            else
            {
                if (progress >= targetMin && progress <= targetMax)
                {
                    print("good job");
                }
                // check if pointer is inside spot
                // give gains
            }
        }
    }
   
}
