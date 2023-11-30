using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCall : MonoBehaviour
{
    [SerializeField] private Bicep bicep;

    public void StartOfAnim()
    {
        bicep.StartOfAnim();
    }
    public void HalfWay()
    {
        bicep.HalfWay();
    }


}
