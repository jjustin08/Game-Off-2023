using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player Instance;

    //stats
    private float weight;
    private float food;
    private float steroids;
    private float energy;

    //private float injuries;
    private float fat;

    private float leftArm;
    private float rightArm;

    private float leftLeg;
    private float rightLeg;

    private float Chest;

    private void Awake()
    {
        Instance = this;
    }


    public void GainLeftArm(float amount)
    {
        leftArm += amount;
    }
    
    public void GainRightArm(float amount)
    {
        rightArm += amount;
    }
}
