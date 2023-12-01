using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    [SerializeField]private GameObject pauseMenu;
    [SerializeField]private InGameUI inGameUI;



    private BaseMachine selectedMachine;
    private BaseMachine enteredMachine;
    [SerializeField] private GameObject playerCharacter;


    private int dayCount = 10;

    private void Awake()
    {
        if(GameManager.Instance == null)
        {
            Instance = this;
        }
        
    }

    public InGameUI GetInGameUI()
    {
        return inGameUI;
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

    public void ExitMachine()
    {
        enteredMachine.ExitMachine();
        playerCharacter.SetActive(true);
        enteredMachine = null;
    }
    private void Update()
    {

        if (enteredMachine != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ExitMachine();
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


        if(Input.GetKeyDown(KeyCode.P))
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


    public void EndDay()
    {
        if(dayCount<= 0)
        {
            // do stuff to reset day/cutscene
            // show end resutls
        }
        else
        {
            dayCount--;

            inGameUI.SetDayCountText(dayCount);
            Player.Instance.GetCharacterStats().StartDay();
        }
    }
    

}
