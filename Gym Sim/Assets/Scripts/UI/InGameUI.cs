using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField]private Slider energyBar;

    public void SetEnergyBarValue(float value)
    {
        energyBar.value = value;
    }

    private void Update()
    {
        SetEnergyBarValue(Player.Instance.GetCharacterStats().GetEnergy()/100);
    }

}
