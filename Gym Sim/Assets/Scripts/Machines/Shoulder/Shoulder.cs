using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : BaseMachine
{
    [SerializeField] private Transform weight;
    [SerializeField] private Transform weight2;

    [SerializeField] private SliderGameCurved slider;
    [SerializeField] private SliderGameCurved slider2;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform startPos2;

    [SerializeField] private Transform endPos;
    [SerializeField] private Transform endPos2;

    [SerializeField] private float moveSpeed = 5.0f;

    private float progress = 0f;


    private void Start()
    {
        slider.machine = this;
        slider2.machine = this;
    }
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
                
                progress = slider.CalculateRotationPercentage() / 100;
                progress = 1 - progress;
                weight.position = Vector3.Lerp(startPos.position, endPos.position, progress);

                weight2.position = Vector3.Lerp(startPos2.position, endPos2.position, progress);

                if(progress <= 0.02f)
                {
                    slider.Activate();
                    slider2.Activate();
                }
            }
            else
        {
            weight.position = Vector3.Lerp(startPos.position, endPos.position, 0);

            
            weight2.position = Vector3.Lerp(startPos2.position, endPos2.position, 0);
        }
        }
    
    private void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isRunning)
            {
                isRunning = true;
                slider.Activate();
                slider2.Activate();
            }
            else
            {
            }
           
        }
    }

    public override void AddGain()
    {
        GainCount++;
        if (GainCount >= GainCountMax)
        {
            GainCount = 0;
            Player.Instance.GetCharacterStats().GainArms(5);
        }
    }

}
