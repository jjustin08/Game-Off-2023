using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField]private Slider energyBar;
    [SerializeField]private TextMeshProUGUI dayCountText;
    [SerializeField]private GameObject fButton;


    public void SetEnergyBarValue(float value)
    {
        energyBar.value = value;
    }

    public void SetDayCountText(int day)
    {
        dayCountText.text = day.ToString();
    }

    private void Update()
    {
        SetEnergyBarValue(Player.Instance.GetCharacterStats().GetEnergy()/100);
    }

    public void ToggleFKey(bool toggle)
    {
        fButton.SetActive(toggle);
    }

}
