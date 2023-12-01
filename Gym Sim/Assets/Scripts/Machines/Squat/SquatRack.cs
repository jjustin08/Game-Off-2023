using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquatRack : BaseMachine
{

    [SerializeField] private Slider slider;


    [SerializeField] private Animator animator;

    private bool isReseting;

    private float pullAmount = 0.1f;
    private float resetSpeed = 0.001f;
    private float targetAmount = 0.728f;
    private float ResistanceAmount = 2f;


    private float animationCounter = 0f;

    public override void EnterMachine()
    {
        base.EnterMachine();
        isRunning = true;
    }
    private void Update()
    {
        if (isActive)
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            slider.value += pullAmount;
        }
    }

    private void MachineUpdate()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        float maxtime = 3;
        if (Mathf.Approximately(animationCounter / maxtime, slider.value))
        {
            animator.SetFloat("Speed", 0);
        }
        else if (animationCounter / maxtime < slider.value)
        {
            animationCounter += Time.deltaTime;
            animator.SetFloat("Speed", 0.5f);
        }
        else if (animationCounter / maxtime > slider.value)
        {
            animationCounter -= Time.deltaTime;
            animator.SetFloat("Speed", -0.5f);
        }

        slider.value -= resetSpeed * (slider.value * ResistanceAmount);

        if (slider.value >= targetAmount && !isReseting)
        {
            isReseting = true;
            Player.Instance.GetCharacterStats().GainLegs(5);
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
