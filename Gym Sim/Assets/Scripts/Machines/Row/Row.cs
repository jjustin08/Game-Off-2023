using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class Row : BaseMachine
{
    [SerializeField] private Slider slider;

    [SerializeField] private Transform character;

    private bool isReseting;

    private float pullAmount = 0.1f;
    private float resetSpeed = 0.001f;
    private float targetAmount = 0.728f;
    private float ResistanceAmount = 5f;
    private void Update()
    {
        if(isActive)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                isRunning = true;
            }
            if (isRunning)
            {
                Controls();
                MachineUpdate();
            }
        }
        
    }
    private void Controls()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            slider.value += pullAmount;
        }
    }

    private void MachineUpdate()
    {
        Vector3 newPos = character.position;
        newPos.x = -slider.value * 2;
        newPos.z = 0;
        character.localPosition = newPos;

        slider.value -= resetSpeed * (slider.value * ResistanceAmount);

        if (slider.value >= targetAmount)
        {
            print("hello jacvob");
            isReseting = true;
        }
        if (isReseting)
        {
            if (slider.value <= 0)
            {
                isReseting = false;
            }
            slider.value -= resetSpeed;
        }
    }
}
