using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MachineInteract))]
public class BaseMachine : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject Character;

    protected bool isActive = false;

    public void EnterMachine()
    {
        Camera.SetActive(true);
        Character.SetActive(true);
        isActive = true;
        // change camera's

        // disable enable controlls
    }
}
