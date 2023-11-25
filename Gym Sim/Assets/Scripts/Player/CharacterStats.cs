using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private float weight;
    private float weightMax = 250;
    //private float food;
    //private float steroids;
    private int energy;

    //private float fat;


    private bool leftArmActive;
    private float leftArm;
    private bool rightArmActive;
    private float rightArm;

    private bool leftLegActive;
    private float leftLeg;
    private bool rightLegActive;
    private float rightLeg;

    private bool ChestActive;
    private float Chest;

    [SerializeField] private BodyBlendControls bodyBlendControls;

    public void CalculateChanges()
    {
        CalculateWeight();
        if (weight <= weightMax)
        {
            // put in all changes into body
        }
        else
        {
            // whatever was not active decrease it
        }
    }
    private void CalculateWeight()
    {
        weight = 100;
        weight += leftArm;
        weight += rightArm;
        weight += leftLeg;
        weight += rightLeg;
        weight += Chest;
    }

    #region ENERGY
    public int GetEnergy()
    {
        return energy; 
    }
    public bool HasEnoughEnergy(int amount)
    {
        return energy >= amount;
    }
    public void UseEnergy(int amount)
    {
        energy -= amount;
    }
    #endregion



    #region BODY
    public void GainLeftArm(float amount)
    {
        leftArm += amount;
    }

    public void GainRightArm(float amount)
    {
        rightArm += amount;
    }

    #endregion

}
