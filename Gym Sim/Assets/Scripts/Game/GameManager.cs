using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    private BaseMachine selectedMachine;
    private BaseMachine enteredMachine;
    [SerializeField] private GameObject playerCharacter;

    private void Awake()
    {
        if(GameManager.Instance == null)
        {
            Instance = this;
        }
        
    }

    public void SelectMachine(BaseMachine mac)
    {
        selectedMachine = mac;
    }

    private void Update()
    {
        if (enteredMachine != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                enteredMachine.ExitMachine();
                playerCharacter.SetActive(true);
                enteredMachine = null;
            }
        }
        if (selectedMachine != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                selectedMachine.EnterMachine();
                playerCharacter.SetActive(false);
                enteredMachine = selectedMachine;
                selectedMachine = null;
            }
        }
        
        // tab for tutorial
    }

    

}
