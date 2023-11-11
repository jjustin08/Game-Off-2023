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

        // disable enable controls
    }

    public void ExitMachine()
    {
        Camera.SetActive(false);
        Character.SetActive(false);
        isActive = false;
    }
}
