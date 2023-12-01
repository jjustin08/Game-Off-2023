using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scale : BaseMachine
{
    [SerializeField] private TextMeshProUGUI weightText;



    public override void EnterMachine()
    {
        base.EnterMachine();

        string weight;

        weight = Player.Instance.GetCharacterStats().CalculateWeight().ToString();

        weightText.text = weight; 
    }


    public void EndDay()
    {
        GameManager.Instance.EndDay();
        
    }
}
