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

        isActive = true;
        SliderGameCurvedRight.machine = this;
        SliderGameCurvedLeft.machine = this;

        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, 0);
        animator.speed = 0.5f;
    }



    private void Update()
    {
        if (isActive)
        {
            TutorialToggle();
        }
        else
        {
            isRunning = false;
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
