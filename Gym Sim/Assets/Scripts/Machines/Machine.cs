using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject Character;

    public void EnterMachine()
    {
        Camera.SetActive(true);
        Character.SetActive(true);
        // change camera's

        // disable enable controlls
    }
}
