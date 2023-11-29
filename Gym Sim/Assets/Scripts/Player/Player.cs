using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player Instance;

    private CharacterStats characterStats;
    
    private void Awake()
    {
        Instance = this;
        

        characterStats = GetComponent<CharacterStats>();
    }

    public CharacterStats GetCharacterStats()
    {
        return characterStats;
    }

   
}
