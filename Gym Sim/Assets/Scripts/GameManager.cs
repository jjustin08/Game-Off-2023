using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    private BaseMachine selectedMachine;
    [SerializeField] private GameObject playerCharacter;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectMachine(BaseMachine mac)
    {
        selectedMachine = mac;
    }

    private void Update()
    {
        if (selectedMachine != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                selectedMachine.EnterMachine();
                playerCharacter.SetActive(false);
                selectedMachine = null;
            }
            
        }
        
    }

}
