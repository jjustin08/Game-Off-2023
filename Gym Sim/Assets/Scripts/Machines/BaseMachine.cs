using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(MachineInteract))]
public class BaseMachine : MonoBehaviour
{
    [SerializeField] private GameObject toActivate;
    [SerializeField] private GameObject toDeActivate;
    [SerializeField] protected GameObject tutorial;

    
    


    protected bool isActive = false;
    protected bool isRunning = false;


    protected int GainCount;
    protected int GainCountMax = 5;
    protected int MissCount;
    protected int MissCountMax = 5;

    public void ExitMachineBro()
    {
        GameManager.Instance.ExitMachine();
    }

    public void TutorialToggle()
    {
        if ((Input.GetKeyDown(KeyCode.T)|| (Input.GetKeyDown(KeyCode.Escape) && tutorial.active)) && tutorial != null)
        {
            tutorial.SetActive(!tutorial.active);
            if (tutorial.active)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
    virtual public void EnterMachine()
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


    virtual public void AddGain()
    {
        GainCount++;
        if (GainCount >= GainCountMax)
        {
            GainCount = 0;
            Player.Instance.GetCharacterStats().GainArms(5);
        }
    }

    public void AddMiss()
    {
        MissCount++;

        if (MissCount >= MissCountMax)
        {
            MissCount = 0;
            GameOver();
        }
    }


    public void GameOver()
    {
        GameManager.Instance.ExitMachine();
        //TODO take energy
    }
}
