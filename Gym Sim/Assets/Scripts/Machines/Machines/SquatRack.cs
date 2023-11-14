using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatRack : BaseMachine
{
    [SerializeField] private Transform rightFoot;
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform head;


    private void CheckBodyPosture()
    {
        //check if all body parts are within zones
    }

}
