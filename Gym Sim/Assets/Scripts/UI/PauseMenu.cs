using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;


    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeButtonPressed);
        optionsButton.onClick.AddListener(OptionsButtonPressed);
        exitButton.onClick.AddListener(ExitButtonPressed);
    }


    private void ResumeButtonPressed()
    {
        GameManager.Instance.UnPausedGame();
    }
    private void OptionsButtonPressed()
    {
        //TODO
    }
    private void ExitButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
