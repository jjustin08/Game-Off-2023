using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player Instance;

    private CharacterStats characterStats;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject victoryScreen;
    private void Awake()
    {
        Instance = this;
        

        characterStats = GetComponent<CharacterStats>();
    }

    public CharacterStats GetCharacterStats()
    {
        return characterStats;
    }


    
    public void SetVictoryAnimation(float score)
    {
        if (victoryScreen.active)
            return;


        GameManager.Instance.ExitEverything();
        victoryScreen.SetActive(true);
        int randomNum = Random.Range(0, 4);

        switch (randomNum)
            {
            case 0:
                animator.Play("Dance1");
                break;
                case 1:
                animator.Play("Dance2");
                break;
                case 2:
                animator.Play("Dance3");
                break;
                case 3:
                animator.Play("Dance4");
                break;
        }


    }

}
