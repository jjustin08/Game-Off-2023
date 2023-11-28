using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MachineInteract))]
public class BaseMachine : MonoBehaviour
{
    [SerializeField] private GameObject toActivate;
    [SerializeField] private GameObject toDeActivate;


    protected bool isActive = false;
    protected bool isRunning = false;

    public void EnterMachine()
    {
        toActivate.SetActive(true);
        isActive = true;
        toDeActivate.SetActive(false);

        // disable enable controls
    }

    public void ExitMachine()
    {
        Player.Instance.GetCharacterStats().PushChanges();
        toActivate.SetActive(false);
        isActive = false;
        toDeActivate.SetActive(true);
    }
}
