using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    private Machine selectedMachine;
    [SerializeField] private GameObject playerCharacter;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectMachine(Machine mac)
    {
        selectedMachine = mac;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            selectedMachine.EnterMachine();
            playerCharacter.SetActive(false);
        }
    }

}
