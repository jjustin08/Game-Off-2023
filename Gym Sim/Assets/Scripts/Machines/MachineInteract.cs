using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class MachineInteract : MonoBehaviour
{
    private BoxCollider boxCollider;

    // have selected gameobject stuff
    [SerializeField] private GameObject selected;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        //TODO change this later
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            selected.SetActive(false);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SelectMachine(GetComponent<BaseMachine>());
            selected.SetActive(true);
        }
        
        // put inside somehwere o be the current selected machine
        // enable ui and make machine glow
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SelectMachine(null);
            selected.SetActive(false);
        }
      
        // unselect machine
    }

}
