using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;


    private void Start()
    {
        startButton.onClick.AddListener(StartButtonPressed);
        optionsButton.onClick.AddListener(OptionsButtonPressed);
        exitButton.onClick.AddListener(ExitButtonPressed);
    }


    private void StartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    } 
    private void OptionsButtonPressed()
    {
        //TODO
    }
    private void ExitButtonPressed()
    {
        Application.Quit();
    }
}
