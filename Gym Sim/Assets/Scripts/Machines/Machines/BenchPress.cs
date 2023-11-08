using UnityEngine;

public class BenchPress : BaseMachine
{
    [SerializeField] private Transform weightLeft;
    [SerializeField] private Transform weightRight;
    [SerializeField] private Transform bar;
    private Animator animator;

    private float pushAmount = 400.0f;
    private float gravityAmount = -5.0f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnConnectedToServer()
    {
        animator.StopPlayback();
    }
    private void Update()
    {
        if(isActive)
        {
            weightLeft.GetComponent<Rigidbody>().AddForce(new Vector3(0, gravityAmount, 0));
            weightRight.GetComponent<Rigidbody>().AddForce(new Vector3(0, gravityAmount, 0));
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PushUpBarLeft();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                PushUpBarRight();
            }
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
        weightLeft.GetComponent<Rigidbody>().AddForce(new Vector3(0, pushAmount, 0));
        //weightLeft.Translate(new Vector3(0, pushAmount, 0));
    }
    
    private void PushUpBarRight()
    {
        weightRight.GetComponent<Rigidbody>().AddForce(new Vector3(0, pushAmount, 0));
        //weightRight.Translate(new Vector3(0, pushAmount, 0));
    }

    private void ResetVelocity()
    {
        weightLeft.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        weightRight.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        bar.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
