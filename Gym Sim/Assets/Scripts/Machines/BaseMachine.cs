using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MachineInteract))]
public class BaseMachine : MonoBehaviour
{
    [SerializeField] private GameObject toActivate;


    protected bool isActive = false;
    protected bool isRunning = false;

    public void EnterMachine()
    {
        toActivate.SetActive(true);
        isActive = true;

        // disable enable controls
    }

    public void ExitMachine()
    {
        toActivate.SetActive(false);
        isActive = false;
    }
}
