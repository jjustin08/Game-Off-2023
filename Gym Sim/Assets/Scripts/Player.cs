using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player Instance;

    

    public CharacterStats stats;

    private void Awake()
    {
        Instance = this;
        stats = GetComponent<CharacterStats>();
    }
}
