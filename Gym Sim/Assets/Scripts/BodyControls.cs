using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyControls : MonoBehaviour
{
    private SkinnedMeshRenderer body;

    private void Awake()
    {
        body = GetComponent<SkinnedMeshRenderer>();
    }


    private void Start()
    {
        body.SetBlendShapeWeight(0,100);
    }
}
