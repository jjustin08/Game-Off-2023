using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    [SerializeField]private GameObject pauseMenu;



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

    public void UnPausedGame()
    {
        if (pauseMenu.active)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
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
            if (Input.GetKeyDown(KeyCode.F) && Player.Instance.GetCharacterStats().HasEnoughEnergy(1))
            {
                selectedMachine.EnterMachine();
                playerCharacter.SetActive(false);
                enteredMachine = selectedMachine;
                selectedMachine = null;
            }
        }


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.active)
            {
                pauseMenu.SetActive(false); 
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale= 0;
            }
            
        }
        
        // tab for tutorial
    }

    

}
