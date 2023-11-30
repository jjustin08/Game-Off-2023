using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Bicep : BaseMachine
{
    [SerializeField] private Animator animator;
    [SerializeField] private SliderGameCurved SliderGameCurvedRight;
    [SerializeField] private SliderGameCurved SliderGameCurvedLeft;

    private int GainCount;
    private int GainCountMax = 5;
    private int MissCount;
    private int MissCountMax = 5;



    override public void EnterMachine()
    {
        base.EnterMachine();


        SliderGameCurvedRight.bicep = this;
        SliderGameCurvedLeft.bicep = this;

        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, 0);
        animator.speed = 0;
    }



    private void Update()
    {
        if (isActive)
        {
            Controls();
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

  public void AddGain()
    {
        GainCount++;
        if(GainCount >= GainCountMax) 
        {
            GainCount = 0;
            Player.Instance.GetCharacterStats().GainArms(5);
        }
    }

    public void AddMiss()
    {
        MissCount++;

        if(MissCount >= MissCountMax)
        {
            MissCount = 0;
            GameOver();
        }
    }


    public void GameOver()
    {
        GameManager.Instance.ExitMachine();
        //TODO take energy
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
