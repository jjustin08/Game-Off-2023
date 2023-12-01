using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class Row : BaseMachine
{

    [SerializeField] private Slider slider;


    [SerializeField] private Animator animator;

    private bool isReseting;

    private float pullAmount = 0.1f;
    private float resetSpeed = 0.001f;
    private float targetAmount = 0.728f;
    private float ResistanceAmount = 2f;


    private float animationCounter = 0f;


    private void Update()
    {
        if(isActive)
        {
            TutorialToggle();
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

    public override void EnterMachine()
    {
        base.EnterMachine();

        isRunning = true;
    }

    private void MachineUpdate()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (Mathf.Approximately(animationCounter / 4.8f, slider.value))
        {
            animator.SetFloat("Speed", 0);
        }
        else if (animationCounter / 4.8f < slider.value)
        {
            animationCounter += Time.deltaTime;
            animator.SetFloat("Speed", 0.5f);
        }
        else if (animationCounter / 4.8f > slider.value)
        {
            animationCounter -= Time.deltaTime;
            animator.SetFloat("Speed", -0.5f);
        }

        slider.value -= resetSpeed * (slider.value * ResistanceAmount);

        if (slider.value >= targetAmount && !isReseting)
        {
            isReseting = true;
            Player.Instance.GetCharacterStats().GainBack(5);
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

    public void StartAnim()
    {
        animationCounter = 0f;
    }

    public void MidAnim()
    {
        animator.SetFloat("Speed", -0.5f);
    }
    
    public void EndAnim()
    {


    }
}
