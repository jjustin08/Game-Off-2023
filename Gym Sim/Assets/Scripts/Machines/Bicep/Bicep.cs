using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Bicep : BaseMachine
{
    [SerializeField] private Animator animator;
    [SerializeField] private SliderGameCurved SliderGameCurvedRight;
    [SerializeField] private SliderGameCurved SliderGameCurvedLeft;





    override public void EnterMachine()
    {
        base.EnterMachine();


        SliderGameCurvedRight.machine = this;
        SliderGameCurvedLeft.machine = this;

        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, 0);
        animator.speed = 0;
    }



    private void Update()
    {
        if (isActive)
        {
            Controls();
            TutorialToggle();
        }
        else
        {
            isRunning = false;
        }
    }

    private void Controls()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isActive = true;

            animator.speed = 0.5f;
        }
    }

 

    public void HalfWay()
    {
        SliderGameCurvedLeft.Activate();
    }

    public void StartOfAnim()
    {

        SliderGameCurvedRight.Activate();
    }

}
