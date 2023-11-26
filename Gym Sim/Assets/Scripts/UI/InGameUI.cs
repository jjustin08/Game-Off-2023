using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField]private Slider energyBar;
    [SerializeField]private Image EnergyImage;

    public void SetEnergyBarValue(float value)
    {
        energyBar.value = value;
    }


    private void test()
    {
        int bro = EnergyImage.fillOrigin;

        print(bro);
    }
}
