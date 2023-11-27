using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBlendControls : MonoBehaviour
{
    private SkinnedMeshRenderer body;

    private static int chest = 0;
    private static int arms = 1;
    private static int shoulders = 2;
    private static int back = 3;
    private static int legs = 4;


    private void Awake()
    {
        body = GetComponent<SkinnedMeshRenderer>();
    }

    public void SetChestSize(float value)
    {
        body.SetBlendShapeWeight(chest, value);
    }
    
    public void SetArmSize(float value)
    {
        body.SetBlendShapeWeight(arms, value);
    }
    
    public void SetShouldersSize(float value)
    {
        body.SetBlendShapeWeight(shoulders, value);
    }
    
    public void SetBackSize(float value)
    {
        body.SetBlendShapeWeight(back, value);
    }
    
    public void SetLegsSize(float value)
    {
        body.SetBlendShapeWeight(legs, value);
    }
    
}
