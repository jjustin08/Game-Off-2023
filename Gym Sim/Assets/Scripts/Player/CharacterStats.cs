using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private float weight = 100;
    private float weightMax = 250;
    //private float food;
    //private float steroids;
    private int energy = 100;
    private int energyMax = 100;

    //private float fat;


    private bool armsActive;
    private float arms;

    private bool legsActive;
    private float legs;

    private bool ChestActive;
    private float Chest;



    [SerializeField]private List<BodyBlendControls> bodyBlendControls;


    
    public void StartDay()
    {
        energy = energyMax;
    }



    public void PushChanges()
    {
        float oldWeight = weight;
        CalculateWeight();
        if (weight <= weightMax)
        {
            // put in all changes into body
        }
        else
        {
            // whatever was not active decrease it
        }

        energy -= (int)weight - (int)oldWeight;
    }
    private void CalculateWeight()
    {
        float baseWeight = 100;
        weight = baseWeight;
        weight += arms;
        weight += legs;
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
    public void GainArms(float amount)
    {
        armsActive = true;
        arms += amount;
        
        foreach(BodyBlendControls body in bodyBlendControls)
        {
            if(body!= null)
            body.SetArmSize(arms);
        }
        
    }
    
    public void GainChest(float amount)
    {
        armsActive = true;
        Chest += amount;
        
        foreach(BodyBlendControls body in bodyBlendControls)
        {
            body.SetChestSize(Chest);
        }
        
    } 
    
    public void GainLegs(float amount)
    {
        armsActive = true;
        legs += amount;
        
        foreach(BodyBlendControls body in bodyBlendControls)
        {
            body.SetChestSize(legs);
        }
        
    }

    public void RemoveGains(float amount)
    {
        int randomNum = Random.Range(0, 5);

        switch(randomNum) 
        {
            case 0:
                GainArms(-5);
                break;
                case 1:
                GainChest(-5);
                break;
                case 2:
                GainLegs(-5);
                                break;  
                case 3:

                                break;
                case 4:

                    break;

        
        
        
        }
    }


    #endregion

}
