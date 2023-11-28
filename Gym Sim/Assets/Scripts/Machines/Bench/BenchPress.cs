using UnityEngine;
using UnityEngine.UI;

public class BenchPress : BaseMachine
{
    [SerializeField] private Slider leftBar;
    [SerializeField] private Slider rightBar;



    [SerializeField] private Rigidbody weightLeft;
    [SerializeField] private Rigidbody weightRight;
    [SerializeField] private Rigidbody bar;

    private float pushAmount = 200.0f;
    private float gravityAmount = -3.0f;
    private float minHeight = 0.045f;
    private float maxHeight = 0.16f;

    private float gainHeight = 0.2f;
    private float restHeight = 0.05f;

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
        float LeftPercent = (weightLeft.transform.localPosition.y - minHeight) / maxHeight;
        float rightPercent = (weightRight.transform.localPosition.y - minHeight) / maxHeight;



        leftBar.value = LeftPercent;
        rightBar.value = rightPercent;
    }
    private void GainsCheck()
    {
        if(weightLeft.transform.localPosition.y >= gainHeight && gainAbleLeft)
        {
            gainAbleLeft = false;
            Player.Instance.GetCharacterStats().GainLeftArm(1);

        }
        else if(weightLeft.transform.localPosition.y <= restHeight)
        {
            gainAbleLeft = true;

        }
        if(weightRight.transform.localPosition.y >= gainHeight && gainAbleRight)
        {
            gainAbleRight = false;
            Player.Instance.GetCharacterStats().GainRightArm(1);

        }
        else if (weightRight.transform.localPosition.y <= restHeight)
        {
            gainAbleRight = true;
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
