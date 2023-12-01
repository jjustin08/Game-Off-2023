using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BenchPress : BaseMachine
{
    [SerializeField] private Slider leftBar;
    [SerializeField] private Slider rightBar;



    [SerializeField] private Rigidbody weightLeft;
    [SerializeField] private Rigidbody weightRight;
    [SerializeField] private Rigidbody bar;

    private float pushAmount = 500.0f;
    private float gravityAmount = -6.0f;
    private float minHeight = -0.15f;
    private float maxHeight = 0.4f;

    private float gainHeight = 0.1f;
    private float restHeight = -0.10f;

    private bool gainAbleLeft = true;
    private bool gainAbleRight = true;


    

    private void Update()
    {
        if (isActive)
        {
            Controls();
            GainsCheck();

            UIUpdate();
        }
    }

    private void UIUpdate()
    {
        float LeftPercent = (weightLeft.transform.localPosition.y -minHeight) / maxHeight;
        float rightPercent = (weightRight.transform.localPosition.y -minHeight ) / maxHeight;




        leftBar.value = LeftPercent;
        rightBar.value = rightPercent;
    }
    private void GainsCheck()
    {
        bool gain = false;
        if(weightLeft.transform.localPosition.y >= gainHeight && gainAbleLeft)
        {
            gain = true;
        }
        else if(weightLeft.transform.localPosition.y <= restHeight)
        {
            gainAbleLeft = true;
        }
        if(weightRight.transform.localPosition.y <= gainHeight && gainAbleRight && gain)
        {
            gain = false;
        }
        else if (weightRight.transform.localPosition.y <= restHeight)
        {
            gainAbleRight = true;
        }

        if(gain)
        {
            gainAbleLeft = false;
            gainAbleRight = false;
            Player.Instance.GetCharacterStats().GainChest(10);
        }

    }

    private void Controls()
    {
        if (weightLeft.transform.localPosition.y <= maxHeight)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PushUpBarLeft();
            }

        }
        if (weightLeft.transform.localPosition.y >= minHeight)
        {
            
            weightLeft.AddForce(new Vector3(0, gravityAmount, 0));
        }

        if (weightRight.transform.localPosition.y <= maxHeight)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PushUpBarRight();
            }

        }
        if (weightRight.transform.localPosition.y >= minHeight)
        {
            weightRight.AddForce(new Vector3(0, gravityAmount, 0));
        }

        
    }

    private void LateUpdate()
    {
        if(isActive) 
        {
            ResetVelocity();
        }
    }


    private void PushUpBarLeft()
    {
        weightLeft.AddForce(new Vector3(0, pushAmount, 0));
    }
    
    private void PushUpBarRight()
    {
        weightRight.AddForce(new Vector3(0, pushAmount, 0));
    }

    private void ResetVelocity()
    {
        weightLeft.velocity = new Vector3(0, 0, 0);
        weightRight.velocity = new Vector3(0, 0, 0);
        bar.velocity = new Vector3(0, 0, 0);
    }
}
