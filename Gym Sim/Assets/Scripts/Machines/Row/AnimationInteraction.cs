using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInteraction : MonoBehaviour
{
    [SerializeField] private Row rowMachine;


    public void StartOfAnim()
    {
        rowMachine.StartAnim();
    }
    public void HalfWay()
    {
        rowMachine.MidAnim();
    }

    public void EndOfAnim()
    {
        rowMachine.EndAnim();
    }

}
