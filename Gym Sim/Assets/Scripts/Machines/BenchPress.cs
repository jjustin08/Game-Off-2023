using UnityEngine;

public class BenchPress : MonoBehaviour
{
    [SerializeField] private Transform weightLeft;
    [SerializeField] private Transform weightRight;
    [SerializeField] private Transform bar;
    private Animator animator;

    private float pushAmount = 0.5f;


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
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PushUpBarLeft();
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            PushUpBarRight();
        }
    }

    private void LateUpdate()
    {
        ResetVelocity();
    }


    private void PushUpBarLeft()
    {
        weightLeft.GetComponent<Rigidbody>().AddForce(new Vector3(0, pushAmount*1000, 0));
        //weightLeft.Translate(new Vector3(0, pushAmount, 0));
    }
    
    private void PushUpBarRight()
    {
        weightRight.GetComponent<Rigidbody>().AddForce(new Vector3(0, pushAmount * 1000, 0));
        //weightRight.Translate(new Vector3(0, pushAmount, 0));
    }

    private void ResetVelocity()
    {
        weightLeft.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        weightRight.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        bar.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
