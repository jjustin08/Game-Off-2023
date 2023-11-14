using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : BaseMachine
{
    [SerializeField] private Transform weight;
    [SerializeField] private Transform weight2;

    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private UnityEngine.UI.Slider slider2;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform startPos2;

    [SerializeField] private Transform endPos;
    [SerializeField] private Transform endPos2;

    [SerializeField] private float moveSpeed = 5.0f;

    private float progress = 0f;

    private void Update()
    {
        if (isActive)
        {
            Controls();
            MachineUpdate();
        }
        else
        {
            isRunning = false;
        }
    }
    private void MachineUpdate()
    {
        if (isRunning)
        {

            float t = Mathf.PingPong(Time.time * moveSpeed, 1.0f);
            progress = t;
            slider.value = progress;
            weight.position = Vector3.Lerp(startPos.position, endPos.position, t);
            
            slider2.value = progress;
            weight2.position = Vector3.Lerp(startPos2.position, endPos2.position, t);

        }
    }


    private void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isRunning)
            {
                isRunning = true;
            }
            else
            {

            }
        }
    }
}
