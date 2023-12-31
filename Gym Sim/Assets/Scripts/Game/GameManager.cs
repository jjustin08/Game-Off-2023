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
    [SerializeField] private Contest contest;

    private bool gameover = false;


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

    public void ExitEverything()
    {
        enteredMachine.ExitMachine();
        enteredMachine = null;
    }
    public void ExitMachine()
    {
        enteredMachine.ExitMachine();
        playerCharacter.SetActive(true);
        enteredMachine = null;
    }
    private void Update()
    {
        if (gameover)
            return;

        if (enteredMachine != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ExitMachine();
            }
        }
        if (selectedMachine != null)
        {
            inGameUI.ToggleFKey(true);
            if (Input.GetKeyDown(KeyCode.F) && (Player.Instance.GetCharacterStats().HasEnoughEnergy(1) || selectedMachine.GetComponent<Scale>() != null))
            {
                selectedMachine.EnterMachine();
                playerCharacter.SetActive(false);
                enteredMachine = selectedMachine;
                selectedMachine = null;
            }
        }
        else
        {
            inGameUI.ToggleFKey(false);
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
        
    }


    public void EndDay()
    {
        dayCount--;
        if (dayCount<= 0)
        {
            gameover = true;
            contest.ActiveContest();
        }
        else
        {
            inGameUI.SetDayCountText(dayCount);
            Player.Instance.GetCharacterStats().StartDay();
        }
    }
    

}
