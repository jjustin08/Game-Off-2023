using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;


    private void Start()
    {
        startButton.onClick.AddListener(StartButtonPressed);

    }


    private void StartButtonPressed()
    {
        SceneManager.LoadScene("GymRoomCreation");
    } 

}
