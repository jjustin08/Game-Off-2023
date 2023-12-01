using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class TreadMill : BaseMachine
{
    private float Counter;
    private float CounterMax = 5;


    public override void EnterMachine()
    {
        base.EnterMachine();

        Counter = 0;
    }


    private void Update()
    {
        if(isActive)
        {
            Counter += Time.deltaTime;

            if (Counter >= CounterMax)
            {
                
                Counter = 0;
                Player.Instance.GetCharacterStats().RemoveGains(5);
            }
        }
        
    }
}
